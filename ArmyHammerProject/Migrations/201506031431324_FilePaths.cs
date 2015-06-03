namespace ArmyHammerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilePaths : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Imatges",
                c => new
                    {
                        ImatgeId = c.Int(nullable: false, identity: true),
                        NomImatge = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        UsuariID = c.Int(nullable: false),
                        Usuari_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ImatgeId)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuari_Id)
                .Index(t => t.Usuari_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Imatges", "Usuari_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Imatges", new[] { "Usuari_Id" });
            DropTable("dbo.Imatges");
        }
    }
}
