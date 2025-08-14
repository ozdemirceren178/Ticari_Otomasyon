namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Personals", "Departmant_DepartmenID", "dbo.Departmants");
            DropIndex("dbo.Personals", new[] { "Departmant_DepartmenID" });
            DropColumn("dbo.Personals", "DepartmanId");
            RenameColumn(table: "dbo.Personals", name: "Departmant_DepartmenID", newName: "DepartmanId");
            AlterColumn("dbo.Personals", "DepartmanId", c => c.Int(nullable: false));
            CreateIndex("dbo.Personals", "DepartmanId");
            AddForeignKey("dbo.Personals", "DepartmanId", "dbo.Departmants", "DepartmenID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personals", "DepartmanId", "dbo.Departmants");
            DropIndex("dbo.Personals", new[] { "DepartmanId" });
            AlterColumn("dbo.Personals", "DepartmanId", c => c.Int());
            RenameColumn(table: "dbo.Personals", name: "DepartmanId", newName: "Departmant_DepartmenID");
            AddColumn("dbo.Personals", "DepartmanId", c => c.Int(nullable: false));
            CreateIndex("dbo.Personals", "Departmant_DepartmenID");
            AddForeignKey("dbo.Personals", "Departmant_DepartmenID", "dbo.Departmants", "DepartmenID");
        }
    }
}
