using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaculdadeXPTO.Models
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }        
        [NotMapped]
        public List<Disciplina> disciplinas { get; set; }
        [NotMapped]
        public List<Aluno> alunos { get; set; }        
    }

    
    public class Turma_Aluno
    {
        [Key]
        public int Id { get; set; }

        public int IdTurma { get; set; }

        public int IdAluno { get; set; }


    }

    public class Turma_Disciplina
    {
        [Key]
        public int Id { get; set; }

        public int IdTurma { get; set; }

        public int IdDisciplina { get; set; }


    }
}