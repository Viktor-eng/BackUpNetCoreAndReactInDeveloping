using DynamicApiController;
using GenericRepository;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class ServerToDrive : BaseEntity
    {
        public int  ServerId { get; set; }

        public int DriveId { get; set; }

        public Drive Drive { get; set; }

        public bool IsBackup { get; set; }
    }
}
