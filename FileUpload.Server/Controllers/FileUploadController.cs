using FileUpload.Server.Models;
using FileUpload.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileUpload.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly FileAttachmentService _fileAttachmentService;

        public FileUploadController(FileAttachmentService fileAttachmentService)
        {
            _fileAttachmentService = fileAttachmentService;
        }

        // POST: api/fileupload/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles([FromForm] FileUploadRequestModel request)
        {
            if (request.Files != null && request.Files.Count > 0)
            {
                // Step 1: Convert files into FileAttachmentModel objects
                var fileModels = new List<FileAttachmentModel>();
                foreach (var file in request.Files)
                {
                    if (file.Length > 0)
                    {
                        using var memoryStream = new MemoryStream();
                        await file.CopyToAsync(memoryStream);
                        var fileData = Convert.ToBase64String(memoryStream.ToArray());

                        fileModels.Add(new FileAttachmentModel
                        {
                            FileName = file.FileName,
                            FileType = file.ContentType,
                            FileData = fileData
                        });
                    }
                }

                // Step 2: Create or retrieve UserInfo and associate files
                var userInfo = await _fileAttachmentService.CreateUserInfoWithFilesAsync(request.FirstName, request.LastName, fileModels);

                return Ok(userInfo);
            }

            return BadRequest("No files were uploaded.");
        }

        [HttpGet("files")]
        public async Task<IActionResult> GetFiles()
        {
            var files = await _fileAttachmentService.GetFilesAsync();
            return Ok(files);
        }

        [HttpGet("files/{id}")]
        public async Task<IActionResult> GetFileById(int id)
        {
            var file = await _fileAttachmentService.GetFileByIdAsync(id);
            if (file == null)
            {
                return NotFound("File not found.");
            }

            return Ok(file);
        }
    }
}
