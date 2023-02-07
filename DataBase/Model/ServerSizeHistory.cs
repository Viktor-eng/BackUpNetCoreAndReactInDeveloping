using DynamicApiController;
using GenericRepository;
using System;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class ServerSizeHistory : BaseEntity
    {
        public int FreeSpace { get; set; }

        public int TotalSpace { get; set; }

        public int ServerToDriveId { get; set; }

        public ServerToDrive ServerToDrive { get; set; }

        public int ServerId { get; set; }

        public DateTime DateTime { get; set; }
    }
}
