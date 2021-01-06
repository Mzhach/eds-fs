using System;

namespace SimpleStorage.Data
{
    public class StoredFile
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public string Filename { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
