using FileUpload.Server.Infastructure;

namespace FileUpload.Server.Models
{
    public class FileAttachmentModel
    {
        public int? Id { get; set; } // The ID of the file attachment

        public string FileName { get; set; } = string.Empty; 

        public string FileType { get; set; } = string.Empty; 

        public string FileData { get; set; } = string.Empty; 

        
    }
}
