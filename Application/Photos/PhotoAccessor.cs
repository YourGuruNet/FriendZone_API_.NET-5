using System;
using System.Threading.Tasks;
using Application.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Infrastructure.Photos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Application.Photos
{
    public class PhotoAccessor : IPhotoAccessor
    {
        private readonly Cloudinary _cloudinary;


        public PhotoAccessor(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                  config.Value.ApiKey,
                    config.Value.ApiSecret
                    );
            _cloudinary = new Cloudinary(account);
                }

        public async Task<PhotoUploadResult> AddPhoto(IFormFile file)
        {
           if (file.Length > 0)
            {
                await using var stream = file.OpenReadStream();
                var uploadPrams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation()
                                    .Width(500).Height(500).Gravity("face").Crop("file")
                };
                var uploadResult = await _cloudinary.UploadAsync(uploadPrams);

                if (uploadResult.Error != null)
                {
                    throw new Exception(uploadResult.Error.Message);
                }

                return new PhotoUploadResult
                {
                    PublicId = uploadResult.PublicId,
                    Url = uploadResult.SecureUrl.ToString()
                };

            }

            return null;
        }

        public async Task<string> DeletePhoto(string publicId)
        {
            var deletParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deletParams);

            return result.Result == "ok" ? result.Result : null;
        }
    }
    
    
}
