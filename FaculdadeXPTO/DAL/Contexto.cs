using FaculdadeXPTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace FaculdadeXPTO.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base("entityFramework")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            Database.SetInitializer<Contexto>(null);

            base.OnModelCreating(modelBuilder);            
        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<FaculdadeXPTO.Models.Disciplina> Disciplinas { get; set; }

        public System.Data.Entity.DbSet<FaculdadeXPTO.Models.Turma> Turmas { get; set; }

        public DbSet<Turma_Aluno> Turma_Alunos { get; set; }

        public DbSet<Turma_Disciplina> Turma_Disciplinas { get; set; }
    }
}