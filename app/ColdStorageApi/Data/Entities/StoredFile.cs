using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColdStorageApi.Data.Entities
{
    public class StoredFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public string Path { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
