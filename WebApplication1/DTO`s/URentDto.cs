using AutoLand_API;
using System.Text.Json.Serialization;

namespace WebApplication1
{
    public class URentDto
    {

        public int CarId { get; set; }
        public DateTime? Start { get; set; }
        public int? Price { get; set; }
    }

}
