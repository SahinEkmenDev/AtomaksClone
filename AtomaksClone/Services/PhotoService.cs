using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace AtomaksClone.Services
{
    public class PhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<string> UploadPhotoAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Quality("auto").FetchFormat("auto")
                };

                var result = await _cloudinary.UploadAsync(uploadParams);
                if (result.Error != null)
                    throw new Exception(result.Error.Message);

                return result.SecureUrl.ToString();
            }
            return string.Empty;
        }
    }
}
