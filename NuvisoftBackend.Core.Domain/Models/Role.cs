using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Rol
    public class Role
    {
        public Guid role_id { get; set; }
        public string role_name { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [JsonPropertyName("Privileges")]
        public List<Privilege> Privileges { get; set; }
    }
}
