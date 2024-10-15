using Bie.Business.ValueObjects;

namespace Bie.Business.Interfaces.HttpServices;
public interface IImageUploadService
{
    Task<string> UploadImage(Base64 imageBase64);
}