namespace SMS.Services.UploadFile.Interface
{
    public interface IUploadfile
    {
        public Task<string> FileUpload(IFormFile file);
    }
}
