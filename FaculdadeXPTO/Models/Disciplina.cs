using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FaculdadeXPTO.Models
{
    
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; } = false;
    }
}