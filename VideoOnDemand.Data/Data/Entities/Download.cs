using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoOnDemand.Data.Data.Entities
{
    public class Download
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(80), Required]
        public string Title { get; set; }
        [MaxLength(1024)]
        public string Url { get; set; }
        
        public Module Module { get; set; }
        public int ModuleId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
