using DynamicApiController;
using GenericRepository;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class BackUpTarget : BaseEntity
    {
        public int DatabaseDefinitionId { get; set; }

        public int StorageId { get; set; }

        public Storage Storage { get; set; }

        public int DriveId { get; set; }

        public Drive Drive { get; set; }

        [Required]
        public string Target { get; set; }
    }
}
