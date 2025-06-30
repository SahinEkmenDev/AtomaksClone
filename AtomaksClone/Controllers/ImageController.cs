using AtomaksClone.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly PhotoService _photoService;

    public ImageController(PhotoService photoService)
    {
        _photoService = photoService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var uploadResult = await _photoService.UploadPhotoAsync(file);
        return Ok(new { imageUrl = uploadResult }); 
    }

}
