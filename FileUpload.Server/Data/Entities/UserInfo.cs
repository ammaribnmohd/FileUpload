using System.Collections.Generic;

namespace FileUpload.Server.Data.Entities
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        
        public ICollection<FileAttachment> FileAttachments { get; set; } = new List<FileAttachment>();
    }
}

