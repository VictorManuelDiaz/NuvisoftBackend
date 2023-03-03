using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Usuarios
    public class User
    {
        public Guid user_id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string id_card { get; set; }
        public Guid school_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }

        [ForeignKey("school_id")]
        [JsonPropertyName("School")]
        public School School { get; set; }
        [JsonPropertyName("Privileges")]
        public List<Privilege> Privileges { get; set; }
    }
}
