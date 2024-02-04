using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectBlog.Models.Domain;
using ProiectBlog.Models.DTO;
using ProiectBlog.Repositories.Interface;

namespace ProiectBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);

            if(ModelState.IsValid)
            {
                var blogImage = new BlogImage
                {
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title = title,
                    DateCreated = DateTime.Now
                };
                blogImage = await imageRepository.Upload(file, blogImage);

                var response = new BlogImageDto
                {
                    Id = blogImage.Id,
                    Title = blogImage.Title,
                    FileName = blogImage.FileName,
                    FileExtension = blogImage.FileExtension,
                    Url = blogImage.Url,
                    DateCreated = blogImage.DateCreated
                };

                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if(file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var images = await imageRepository.GetAll();

            var response = new List<BlogImageDto>();

            foreach(var image in images)
            {
                response.Add(new BlogImageDto
                {
                    FileExtension = image.FileExtension,
                    FileName = image.FileName,
                    Url = image.Url,
                    Title = image.Title,
                    DateCreated = image.DateCreated
                });
            }

            return Ok(response);
        }
    }
}
