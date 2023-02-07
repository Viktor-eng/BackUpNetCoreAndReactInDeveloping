using DynamicApiController;
using GenericRepository;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class StorageToDrive : BaseEntity
    {
        public int StorageId { get; set; }

        public int DriveId { get; set; }

        public Drive Drive { get; set; }

        public bool IsBackup { get; set; }
    }
}
