using Agende.Business.Enums;
using Agende.Business.Interfaces.HttpServices;
using Agende.Business.Interfaces.Repositories;
using Agende.Business.Interfaces.Repositories.Base;
using Agende.Business.Interfaces.Services;
using Agende.Business.Models;
using Agende.Business.Services.Base;
using Agende.Business.Services.HttpServices;

namespace Agende.Business.Services;

public class CompanyService : Service<Company>, ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IOpenAIService _openAIService;
    private readonly IImageUploadService _imageService;
    public CompanyService(IRepository<Company> repositoryBase, ICompanyRepository companyRepository, IOpenAIService openAIService, IImageUploadService imageService) : base(repositoryBase)
    {
        _companyRepository = companyRepository;
        _openAIService = openAIService;
        _imageService = imageService;
    }
    public void Validate(Company entity)
    {
        if (string.IsNullOrWhiteSpace(entity.Name))
            throw new ArgumentException("Name is required");
        if (!entity.OpeningHours.Any())
            throw new ArgumentException("At least one opening hour is required");
    }
    public override Task<Company> GetByIdAsync(Guid id, bool active = true)
    {
        return _companyRepository.GetByIdAsync(id, active);
    }
    public async Task<Company> CreateCompanyAsync(Company entity, Guid userId)
    {
        Validate(entity);

        if (!string.IsNullOrWhiteSpace(entity.ImageBase64))
            entity.ImageUrl = await _imageService.UploadImage(entity.ImageBase64);

        entity.Employeers =
        [
            new() {
                UserId = userId,
                IsOwner = true,
            }
        ];

        return await _companyRepository.NewSaveAsync(entity);
    }

    public async Task<IEnumerable<Company>> GetCompaniesByUserAsync(Guid userId)
    {
        return await _companyRepository.GetCompaniesByUserAsync(userId);
    }

    public async Task TemporaryDeleteAsync(Guid id)
    {
        await _companyRepository.TemporaryDeleteAsync(id);
    }

    public async Task ReactiveAsync(Guid id)
    {
        await _companyRepository.ReactiveAsync(id);
    }

    private async Task GenerateImage(Company entity)
    {

        string prompt = @$"Create a distinctive and versatile logo for a forward-thinking business with the following parameters:

        **Company Name:** {entity.Name}.
        **Company Description:** {entity.Description}.

        Capture the essence of the company in the logo, embodying qualities such as innovation, elegance, and adaptability. Infuse the design with a balance of timelessness and modernity to ensure broad appeal.

        Consider the following design elements to guide logo creation:

        1. **Color Palette:** Use a dynamic and versatile color palette to convey the brand's adaptability. Consider a combination of deep blues and vibrant oranges, creating a modern and energetic feel.

        2. **Shapes and Symbols:** Incorporate versatile shapes or symbols that can resonate with a variety of industries. Consider abstract geometric shapes that suggest forward movement and adaptability.

        3. **Typography:** Choose a clean and modern font or typography style that can be easily adaptable to different business sectors. Opt for sans-serif fonts like Montserrat or Proxima Nova for a contemporary look.

        4. **Iconography:** Integrate abstract or versatile icons to represent the brand’s adaptability and forward-thinking nature. Consider incorporating a sleek, abstract arrow or a dynamic, interconnected network of lines to convey innovation and connectivity.

        5. **Layout Preferences:** Consider a flexible layout that allows for variations in size and application. Opt for a balanced and versatile layout with the company name and icon, allowing for easy scalability and recognition.

        Strive for a logo that makes a strong visual impact, leaving a positive and memorable impression. Experiment with various elements to create a design that can be universally appealing. The goal is to provide a logo that can adapt seamlessly to different industries and convey a sense of innovation and excellence.
        ";

        entity.ImageBase64 = await _openAIService.GetBase64NewImageAsync(prompt.Replace("\n", " ").Replace("  ", ""));
    }
}