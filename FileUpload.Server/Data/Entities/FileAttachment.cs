namespace FileUpload.Server.Data.Entities
{
    public class FileAttachment
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; }
        public string FileData { get; set; } = string.Empty;

     
        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }  
    }
}
