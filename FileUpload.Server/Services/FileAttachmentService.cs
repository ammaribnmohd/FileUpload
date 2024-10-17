using FileUpload.Server.Data;
using FileUpload.Server.Models;
using FileUpload.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Server.Services
{
    public class FileAttachmentService
    {
        private readonly AppDbContext _context;

        public FileAttachmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserInfo> CreateUserInfoWithFilesAsync(string firstName, string lastName, List<FileAttachmentModel> fileModels)
        {
            // Check if the user already exists in the database
            var existingUser = await _context.UserInfos
                .FirstOrDefaultAsync(u => u.FirstName == firstName && u.LastName == lastName);

            if (existingUser == null)
            {
                // If user not present, create a new user
                existingUser = new UserInfo
                {
                    FirstName = firstName,
                    LastName = lastName,
                    FileAttachments = fileModels.Select(f => new FileAttachment
                    {
                        FileName = f.FileName,
                        FileType = f.FileType,
                        FileData = f.FileData
                    }).ToList()
                };

                _context.UserInfos.Add(existingUser);
            }
            else
            {
                // If the user exists, add new files to their collection
                foreach (var fileModel in fileModels)
                {
                    var fileAttachment = new FileAttachment
                    {
                        FileName = fileModel.FileName,
                        FileType = fileModel.FileType,
                        FileData = fileModel.FileData,
                        UserInfoId = existingUser.Id // Link file to existing user
                    };
                    existingUser.FileAttachments.Add(fileAttachment);
                    _context.FileAttachments.Add(fileAttachment);
                }
            }

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<List<FileAttachment>> GetFilesAsync()
        {
            return await _context.FileAttachments
                .Include(f => f.UserInfo)  // Include user information in results
                .ToListAsync();
        }

        public async Task<FileAttachment?> GetFileByIdAsync(int id)
        {
            return await _context.FileAttachments
                .Include(f => f.UserInfo)  // Include user information in results
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
