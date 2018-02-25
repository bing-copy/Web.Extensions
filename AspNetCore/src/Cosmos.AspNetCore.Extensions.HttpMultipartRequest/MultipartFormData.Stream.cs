using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Cosmos.AspNetCore.Extensions {
    public class StreamMultipartFormData {
        public StreamMultipartFormData(Dictionary<string, StringValues> forms, List<StreamMultipartFileInfo> files) {
            Files = files;
            FormValues = forms;
        }

        public Dictionary<string, StringValues> FormValues { get; }

        public List<StreamMultipartFileInfo> Files { get; }
    }
}