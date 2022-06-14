using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Lorem { get; set; }
        public string Images { get; set; }
        [NotMapped]
        public IFormFile  Iphoto { get; set; }
    }
}
