using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FaculdadeXPTO.Models
{
    public class Aluno
    {
        [Key]
        //[Column("Name", Order = 1, TypeName = "varchar")]
        [DisplayName("Matrícula")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string cpf { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; } = false;
    }
}