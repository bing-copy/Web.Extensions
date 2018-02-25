using System.IO;

namespace Cosmos.AspNetCore.Extensions {
    public class StreamMultipartFileInfo : MultipartFileInfo {
        public Stream Stream { get; set; }
    }
}