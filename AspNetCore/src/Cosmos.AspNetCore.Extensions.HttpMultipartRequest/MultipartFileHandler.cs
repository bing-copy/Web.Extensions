using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace Cosmos.AspNetCore.Extensions {
    public static class MultipartFileHandler {
        public static Func<string, MultipartSection, MultipartFileInfo, Task<string>> Default = async (folder, fileSection, formFile) => {
            var targetFilePath = Path.Combine(folder, Guid.NewGuid().ToString());
            using (var targetStream = File.Create(targetFilePath)) {
                await fileSection.Body.CopyToAsync(targetStream);
            }

            return targetFilePath;
        };
    }
}