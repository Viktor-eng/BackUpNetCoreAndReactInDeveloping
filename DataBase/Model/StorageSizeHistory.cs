using DynamicApiController;
using GenericRepository;
using System;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class StorageSizeHistory : BaseEntity
    {
        public int StorageId { get; set; }

        public int StorageToDriveId { get; set; }

        public StorageToDrive StorageToDrive { get; set; }

        public int FreeSpace { get; set; }

        public int TotalSpace { get; set; }

        public DateTime DateTime { get; set; }
    }
}
