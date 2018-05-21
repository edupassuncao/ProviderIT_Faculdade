namespace FaculdadeXPTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projetofaculdade : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Aluno", newName: "Alunoes");
            RenameTable(name: "dbo.Disciplina", newName: "Disciplinas");
            AddColumn("dbo.Disciplinas", "Nome", c => c.String());
            DropColumn("dbo.Disciplinas", "Descricao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Disciplinas", "Descricao", c => c.String());
            DropColumn("dbo.Disciplinas", "Nome");
            RenameTable(name: "dbo.Disciplinas", newName: "Disciplina");
            RenameTable(name: "dbo.Alunoes", newName: "Aluno");
        }
    }
}
