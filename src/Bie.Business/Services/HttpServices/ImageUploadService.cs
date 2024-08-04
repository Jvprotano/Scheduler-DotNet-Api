using Bie.Business.Interfaces.HttpServices;
using Microsoft.Extensions.Configuration;

using Azure.Storage.Blobs;

using System.Text.RegularExpressions;

namespace Bie.Business.Services.HttpServices;
public class ImageUploadService : IImageUploadService
{
    private readonly string _azureStorage;
    private readonly string _azureContainer;

    public ImageUploadService(IConfiguration configuration)
    {
        _azureStorage = configuration["AzureCfg:StorageCfg"] ?? throw new ArgumentException(nameof(configuration));
        _azureContainer = configuration["AzureCfg:Container"] ?? throw new ArgumentException(nameof(configuration));
    }

    public async Task<string> UploadImage(string imageBase64)
    {
        string fileName = Guid.NewGuid().ToString() + ".jpg";
        var data = new Regex(@"data:image\/[a-z]+;base64,").Replace(imageBase64, "");

        byte[] bytes = Convert.FromBase64String(data);

        var blobClient = new BlobClient(_azureStorage, _azureContainer, fileName);

        using (var strem = new MemoryStream(bytes))
        { 
            await blobClient.UploadAsync(strem);
        }

        return blobClient.Uri.AbsoluteUri;
    }
}