using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    public class Privilege
    {
        public Guid privilege_id { get; set; }
        public Guid role_id { get; set; }
        public Guid user_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("role_id")]
        [JsonPropertyName("Role")]
        public Role Role { get; set; }
        [ForeignKey("user_id")]
        [JsonPropertyName("User")]
        public User User { get; set; }
        [JsonPropertyName("PrivilegesSubject")]
        public List<PrivilegeSubject> PrivilegesSubject { get; set; }
    }
}
