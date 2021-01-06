using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleStorage.Data;

namespace SimpleStorage.Controllers
{
    [ApiController]
    [Route("api/objects")]
    public class ObjectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly StorageContext _context;

        public ObjectController(IConfiguration configuration, StorageContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var file = await _context.StoredFiles.SingleOrDefaultAsync(x => x.Id == id);
            if (file == null)
            {
                return NotFound();
            }

            var fileStream = new FileStream(file.Path, FileMode.Open, FileAccess.Read);

            return File(fileStream, MimeTypes.GetMimeType(file.Filename), file.Filename);
        }

        [HttpPut]
        public async Task<IActionResult> Put(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("File is missing");
            }

            if (file.Length > 10000000)
            {
                return BadRequest("File is bigger than 10 MB");
            }

            var path = $"{_configuration["StoragePath"]}/{Guid.NewGuid():D}.bin";

            await using (var fileStream = System.IO.File.Create(path))
            {
                await file.CopyToAsync(fileStream);
            }

            var storedFile = new StoredFile
            {
                Path = path,
                Filename = file.FileName,
                CreatedAt = DateTime.UtcNow
            };

            await _context.StoredFiles.AddAsync(storedFile);
            await _context.SaveChangesAsync();

            return Ok(storedFile.Id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var file = await _context.StoredFiles.SingleOrDefaultAsync(x => x.Id == id);
            if (file == null)
            {
                return NotFound();
            }

            _context.Remove(file);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
