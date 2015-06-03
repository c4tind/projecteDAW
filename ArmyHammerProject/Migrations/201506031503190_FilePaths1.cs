namespace ArmyHammerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePaths1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Imatges", "Usuari_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Imatges", new[] { "Usuari_Id" });
            AddColumn("dbo.Imatges", "Miniatura_ID", c => c.Int());
            CreateIndex("dbo.Imatges", "Miniatura_ID");
            AddForeignKey("dbo.Imatges", "Miniatura_ID", "dbo.Miniaturas", "ID");
            DropColumn("dbo.Imatges", "Usuari_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Imatges", "Usuari_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Imatges", "Miniatura_ID", "dbo.Miniaturas");
            DropIndex("dbo.Imatges", new[] { "Miniatura_ID" });
            DropColumn("dbo.Imatges", "Miniatura_ID");
            CreateIndex("dbo.Imatges", "Usuari_Id");
            AddForeignKey("dbo.Imatges", "Usuari_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
