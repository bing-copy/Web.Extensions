using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cosmos.AspNetCore.Extensions.Internals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace Cosmos.AspNetCore.Extensions {
    public static class MultipartFormDataFactory {

        private static readonly int BONDARY_LENGTH_LIMIT = 1024;
        private static readonly int BUFFER_SIZE = 81920;

        public static StreamMultipartFormData Create(HttpRequest request) {
            return CreateAsync(request).GetAwaiter().GetResult();
        }

        public static LocalMultipartFormData Create(HttpRequest request, string folderPath) {
            return CreateAsync(request, folderPath).GetAwaiter().GetResult();
        }

        public static LocalMultipartFormData Create(HttpRequest request, string folderPath, Func<string, MultipartSection, MultipartFileInfo, Task<string>> fileHandle) {
            return CreateAsync(request, folderPath, fileHandle).GetAwaiter().GetResult();
        }

        public static LocalMultipartFormData Create(HttpRequest request, Func<MultipartSection, MultipartFileInfo, Task<string>> fileHandle) {
            return CreateAsync(request, fileHandle).GetAwaiter().GetResult();
        }

        public static async Task<StreamMultipartFormData> CreateAsync(HttpRequest request) {
            if (request == null) throw new ArgumentNullException(nameof(request));

            if (!MultipartRequestHelper.IsMultipartContentType(request.ContentType)) {
                throw new InvalidDataException("Request is not a multipart request");
            }

            var files = new List<StreamMultipartFileInfo>();
            var formAccumulator = new KeyValueAccumulator();
            var reader = GetMultipartReader(request);

            var section = await reader.ReadNextSectionAsync();

            while (section != null) {
                var hasContentDispositionHeader =
                    ContentDispositionHeaderValue.TryParse(
                        section.ContentDisposition,
                        out ContentDispositionHeaderValue contentDisposition);

                if (hasContentDispositionHeader) {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition)) {
                        var formFile = new StreamMultipartFileInfo {
                            Name = section.AsFileSection().Name,
                            FileName = section.AsFileSection().FileName,
                            Length = section.Body.Length,
                            Stream = section.Body
                        };

                        files.Add(formFile);
                    } else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition)) {
                        formAccumulator = await AccumulateForm(formAccumulator, section, contentDisposition);
                    }
                }

                section = await reader.ReadNextSectionAsync();
            }

            return new StreamMultipartFormData(formAccumulator.GetResults(), files);
        }

        public static async Task<LocalMultipartFormData> CreateAsync(HttpRequest request, string folderPath) {
            return await CreateAsync(request, folderPath, MultipartFileHandler.Default);
        }

        public static async Task<LocalMultipartFormData> CreateAsync(HttpRequest request, string folderPath,
            Func<string, MultipartSection, MultipartFileInfo, Task<string>> fileHandle) {
            if (request == null) throw new ArgumentNullException(nameof(request));

            if (!MultipartRequestHelper.IsMultipartContentType(request.ContentType)) {
                throw new InvalidDataException("Request is not a multipart request");
            }

            var files = new List<LocalMultipartFileInfo>();
            var formAccumulator = new KeyValueAccumulator();
            var reader = GetMultipartReader(request);

            var section = await reader.ReadNextSectionAsync();

            while (section != null) {
                var hasContentDispositionHeader =
                    ContentDispositionHeaderValue.TryParse(
                        section.ContentDisposition,
                        out ContentDispositionHeaderValue contentDisposition);

                if (hasContentDispositionHeader) {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition)) {
                        var formFile = new MultipartFileInfo {
                            Name = section.AsFileSection().Name,
                            FileName = section.AsFileSection().FileName,
                            Length = section.Body.Length
                        };

                        var savingPath = await fileHandle(folderPath, section, formFile);

                        files.Add(new LocalMultipartFileInfo(formFile) {TemporaryLocation = savingPath});
                    } else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition)) {
                        formAccumulator = await AccumulateForm(formAccumulator, section, contentDisposition);
                    }
                }

                section = await reader.ReadNextSectionAsync();
            }

            return new LocalMultipartFormData(formAccumulator.GetResults(), files);
        }

        public static async Task<LocalMultipartFormData> CreateAsync(HttpRequest request,
            Func<MultipartSection, MultipartFileInfo, Task<string>> fileHandle) {
            if (request == null) throw new ArgumentNullException(nameof(request));

            if (!MultipartRequestHelper.IsMultipartContentType(request.ContentType)) {
                throw new InvalidDataException("Request is not a multipart request");
            }

            var files = new List<LocalMultipartFileInfo>();
            var formAccumulator = new KeyValueAccumulator();
            var reader = GetMultipartReader(request);

            var section = await reader.ReadNextSectionAsync();

            while (section != null) {
                var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(
                    section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader) {
                    if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition)) {
                        var formFile = new MultipartFileInfo {
                            Name = section.AsFileSection().Name,
                            FileName = section.AsFileSection().FileName,
                            Length = section.Body.Length
                        };

                        var savingPath = await fileHandle(section, formFile);

                        files.Add(new LocalMultipartFileInfo(formFile) {TemporaryLocation = savingPath});
                    } else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition)) {
                        formAccumulator = await AccumulateForm(formAccumulator, section, contentDisposition);
                    }
                }

                section = await reader.ReadNextSectionAsync();
            }

            return new LocalMultipartFormData(formAccumulator.GetResults(), files);
        }

        private static MultipartReader GetMultipartReader(HttpRequest request) {
            var boundary = MultipartRequestHelper.GetBoundary(MediaTypeHeaderValue.Parse(request.ContentType), BONDARY_LENGTH_LIMIT);
            return new MultipartReader(boundary, request.Body);
        }

        private static async Task<KeyValueAccumulator> AccumulateForm(KeyValueAccumulator formAccumulator, MultipartSection section,
            ContentDispositionHeaderValue contentDisposition) {
            var key = MultipartRequestHelper.RemoveQuotes(contentDisposition.Name.Value);
            var encoding = MultipartRequestHelper.GetEncoding(section);
            using (var streamReader = new StreamReader(
                section.Body,
                encoding,
                detectEncodingFromByteOrderMarks: true,
                bufferSize: BUFFER_SIZE,
                leaveOpen: true)) {
                var value = await streamReader.ReadToEndAsync();
                if (string.Equals(value, "undefined", StringComparison.OrdinalIgnoreCase)) {
                    value = string.Empty;
                }

                formAccumulator.Append(key, value);

                if (formAccumulator.ValueCount > FormReader.DefaultValueCountLimit) {
                    throw new InvalidDataException($"Form key count limit {FormReader.DefaultValueCountLimit} exceeded.");
                }
            }

            return formAccumulator;
        }
    }
}