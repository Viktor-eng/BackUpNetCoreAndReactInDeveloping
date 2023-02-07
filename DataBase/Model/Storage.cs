using DynamicApiController;
using GenericRepository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class Storage : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [Required]
        public string GrpcServiceUrl { get; set; }

        public List<StorageSizeHistory> StorageSizeHistories { get; set; }

        public List<StorageToDrive> StorageToDrives { get; set; }
    }
}
