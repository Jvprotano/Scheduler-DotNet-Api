namespace Agende.Business.Interfaces.HttpServices;
public interface IImageUploadService
{
    Task<string> UploadImage(string imageBase64);
}