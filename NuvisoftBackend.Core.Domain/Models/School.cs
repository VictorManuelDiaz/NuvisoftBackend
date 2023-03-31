using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Colegio
    public class School
    {
        public Guid school_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string address { get; set; }
        public string logo { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [JsonPropertyName("Users")]
        public List<User> Users { get; set; }
        [JsonPropertyName("Group")]
        public List<Group> Groups { get; set; }

    }
}
