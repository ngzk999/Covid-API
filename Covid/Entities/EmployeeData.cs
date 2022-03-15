using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covid.Entities
{
    public class EmployeeData
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string ContactNumber { get; set; }
        public string Temperature { get; set; }
        [JsonIgnore]
        [Column(TypeName = "Date")]
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
