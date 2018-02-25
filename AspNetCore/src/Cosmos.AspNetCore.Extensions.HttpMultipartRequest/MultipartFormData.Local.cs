using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace Cosmos.AspNetCore.Extensions {
    public class LocalMultipartFormData {
        public LocalMultipartFormData(Dictionary<string, StringValues> forms, List<LocalMultipartFileInfo> files) {
            Files = files;
            FormValues = forms;
        }

        public Dictionary<string, StringValues> FormValues { get; }

        public List<LocalMultipartFileInfo> Files { get; }
    }
}