using Microsoft.AspNetCore.Mvc;
using SMS.Services.UploadFile.Interface;

namespace SMS.Services.UploadFile
{
    public class UploadFile: IUploadfile
    {
        private readonly IWebHostEnvironment _henv;
        public UploadFile(IWebHostEnvironment henv)
        {
            _henv = henv;
        }
        public async Task<string> FileUpload(IFormFile file)
        {
            try
            {
                if (file == null && file.Length == 0)
                {
                    throw new Exception("Please select a profile photo.");
                }

                string filename = string.Empty;
                long maxFileSize = (2 * 1024 * 1024); // 2 MB

                if (file.Length > maxFileSize)
                {
                    throw new Exception("Sorry! File Size exceeds 2MB");
                }

                string ext = Path.GetExtension(file.FileName);
                if (ext ==".jpg" ||ext == ".png" || ext == ".JPG")
                {

                }
                else 
                {
                    throw new Exception("Sorry! File format is not allowed.");
                }

                string fName = Path.GetFileName(file.FileName);
                string root = _henv.WebRootPath;
                string dir = "UploadFile";
                var uniqueFileName = $"{Guid.NewGuid().ToString()}_{fName}";
                string filePath = Path.Combine(root, dir, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var fileName = uniqueFileName;
                return fileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
