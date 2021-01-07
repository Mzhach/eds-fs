using System;
using System.IO;
using System.Threading.Tasks;
using ColdStorageApi.Data;
using ColdStorageApi.Data.Entities;
using ColdStorageApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace ColdStorageApi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly StorageContext _storageContext;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public FilesController(StorageContext storageContext, IConfiguration configuration, ILogger logger)
        {
            _storageContext = storageContext;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var storedFile = await _storageContext.StoredFiles.SingleOrDefaultAsync(x => x.Id == id);
                if (storedFile == null)
                {
                    return NotFound();
                }

                var fs = new FileStream(storedFile.Path, FileMode.Open, FileAccess.Read);

                return File(fs, "application/octet-stream");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(AddFileModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Model is missing");
                }

                if (model.File == null || model.File.Length == 0)
                {
                    return BadRequest("File is missing");
                }

                var path = $"{_configuration["StoragePath"]}/{Guid.NewGuid():D}.bin";

                await using (var fileStream = System.IO.File.Create(path))
                {
                    await model.File.CopyToAsync(fileStream);
                }

                await _storageContext.StoredFiles.AddAsync(new StoredFile
                {
                    Id = model.Id,
                    Path = path,
                    CreatedAt = DateTime.UtcNow
                });

                await _storageContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return BadRequest(ex.Message);
            }

            await Task.CompletedTask;
            return Ok();
        }
    }
}
