using Microsoft.AspNetCore.Http;

namespace ColdStorageApi.Models
{
    public class AddFileModel
    {
        public long Id { get; set; }
        public IFormFile File { get; set; }
    }
}
