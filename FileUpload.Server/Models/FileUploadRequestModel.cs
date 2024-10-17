using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileUpload.Server.Models
{
    public class FileUploadRequestModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public List<IFormFile> Files { get; set; } = new List<IFormFile>(); 
    }
}
