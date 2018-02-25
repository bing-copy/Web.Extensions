namespace Cosmos.AspNetCore.Extensions {
    public class LocalMultipartFileInfo : MultipartFileInfo {
        public LocalMultipartFileInfo() { }

        public LocalMultipartFileInfo(MultipartFileInfo fileInfo) {
            FileName = fileInfo.FileName;
            Length = fileInfo.Length;
            Name = fileInfo.Name;
        }

        public string TemporaryLocation { get; set; }
    }
}