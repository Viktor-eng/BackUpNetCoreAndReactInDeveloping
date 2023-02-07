using DynamicApiController;
using GenericRepository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class Server : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [Required]
        public string GrpcServiceUrl { get; set; }

        public List<DatabaseDefinition> DatabaseDefinitions { get; set; }

        public List<ServerSizeHistory> ServerSizeHistories { get; set; }

        public List<ServerToDrive> ServerToDrives { get; set; }
    }
}
