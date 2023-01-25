using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Domain.Models
{
    //Modelo Preguntas
    public class Question
    {
        public Guid question_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int score { get; set; }
        public Guid template_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Guid created_by { get; set; }
        public Guid updated_by { get; set; }
        [ForeignKey("template_id")]
        public Template Template { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
