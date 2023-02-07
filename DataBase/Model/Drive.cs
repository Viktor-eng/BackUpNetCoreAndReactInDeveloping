using DynamicApiController;
using GenericRepository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Model
{
    [GeneratedController("[Controller]")]
    public class Drive : BaseEntity
    {
        [Required]
        public string Letter { get; set; }
    } 
}
