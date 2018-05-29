namespace MaterialWpfApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpensesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CatalogIndexNutritional",
                c => new
                    {
                        Id_index = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20, unicode: false),
                        Unit = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.Id_index);
            
            CreateTable(
                "dbo.FNutritionalCharacteristics",
                c => new
                    {
                        Id_task = c.Int(nullable: false),
                        Id_korm = c.Int(nullable: false),
                        Id_index = c.Int(nullable: false),
                        Id_category = c.Int(nullable: false),
                        FValue = c.Decimal(precision: 10, scale: 3),
                    })
                .PrimaryKey(t => new { t.Id_task, t.Id_korm, t.Id_index })
                .ForeignKey("dbo.Korm", t => t.Id_korm)
                .ForeignKey("dbo.NutritionalCategories", t => t.Id_category)
                .ForeignKey("dbo.Task", t => t.Id_task)
                .ForeignKey("dbo.CatalogIndexNutritional", t => t.Id_index)
                .Index(t => t.Id_task)
                .Index(t => t.Id_korm)
                .Index(t => t.Id_index)
                .Index(t => t.Id_category);
            
            CreateTable(
                "dbo.Korm",
                c => new
                    {
                        Id_korm = c.Int(nullable: false),
                        Korm_category = c.Int(nullable: false),
                        Name_korm = c.String(nullable: false, maxLength: 50, unicode: false),
                        Price_korm = c.Decimal(precision: 9, scale: 2),
                        Unit = c.String(maxLength: 50, unicode: false),
                        Voluminousness = c.String(maxLength: 3, unicode: false),
                    })
                .PrimaryKey(t => t.Id_korm);
            
            CreateTable(
                "dbo.NNutritionalCharacteristics",
                c => new
                    {
                        Id_category = c.Int(nullable: false),
                        Id_index = c.Int(nullable: false),
                        Id_korm = c.Int(nullable: false),
                        NValue = c.Decimal(precision: 10, scale: 3),
                    })
                .PrimaryKey(t => new { t.Id_category, t.Id_index })
                .ForeignKey("dbo.NutritionalCategories", t => t.Id_category)
                .ForeignKey("dbo.Korm", t => t.Id_korm)
                .ForeignKey("dbo.CatalogIndexNutritional", t => t.Id_index)
                .Index(t => t.Id_category)
                .Index(t => t.Id_index)
                .Index(t => t.Id_korm);
            
            CreateTable(
                "dbo.NutritionalCategories",
                c => new
                    {
                        Id_category = c.Int(nullable: false, identity: true),
                        Id_faza = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        VolumeOfMilk = c.Int(),
                        Fat_content = c.Decimal(precision: 3, scale: 2),
                        Protein = c.Decimal(precision: 3, scale: 2),
                    })
                .PrimaryKey(t => t.Id_category)
                .ForeignKey("dbo.Faza", t => t.Id_faza)
                .Index(t => t.Id_faza);
            
            CreateTable(
                "dbo.Faza",
                c => new
                    {
                        Id_faza = c.Int(nullable: false, identity: true),
                        Faza = c.String(nullable: false, maxLength: 20, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id_faza);
            
            CreateTable(
                "dbo.RationCow",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MilkId = c.Int(nullable: false),
                        KormId = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Milk", t => t.MilkId)
                .ForeignKey("dbo.Korm", t => t.KormId)
                .Index(t => t.MilkId)
                .Index(t => t.KormId);
            
            CreateTable(
                "dbo.Milk",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MilkQuantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ration",
                c => new
                    {
                        Id_ration = c.Int(nullable: false),
                        Id_korm = c.Int(nullable: false),
                        Id_task = c.Int(nullable: false),
                        Heft = c.Decimal(precision: 10, scale: 3),
                    })
                .PrimaryKey(t => new { t.Id_ration, t.Id_korm })
                .ForeignKey("dbo.Task", t => t.Id_task)
                .ForeignKey("dbo.Korm", t => t.Id_korm)
                .Index(t => t.Id_korm)
                .Index(t => t.Id_task);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id_task = c.Int(nullable: false, identity: true),
                        Task = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id_task);
            
            CreateTable(
                "dbo.Storage",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        KormId = c.Int(),
                        Quantity = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korm", t => t.KormId)
                .Index(t => t.KormId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Article = c.String(),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NNutritionalCharacteristics", "Id_index", "dbo.CatalogIndexNutritional");
            DropForeignKey("dbo.FNutritionalCharacteristics", "Id_index", "dbo.CatalogIndexNutritional");
            DropForeignKey("dbo.Storage", "KormId", "dbo.Korm");
            DropForeignKey("dbo.Ration", "Id_korm", "dbo.Korm");
            DropForeignKey("dbo.Ration", "Id_task", "dbo.Task");
            DropForeignKey("dbo.FNutritionalCharacteristics", "Id_task", "dbo.Task");
            DropForeignKey("dbo.RationCow", "KormId", "dbo.Korm");
            DropForeignKey("dbo.RationCow", "MilkId", "dbo.Milk");
            DropForeignKey("dbo.NNutritionalCharacteristics", "Id_korm", "dbo.Korm");
            DropForeignKey("dbo.NNutritionalCharacteristics", "Id_category", "dbo.NutritionalCategories");
            DropForeignKey("dbo.FNutritionalCharacteristics", "Id_category", "dbo.NutritionalCategories");
            DropForeignKey("dbo.NutritionalCategories", "Id_faza", "dbo.Faza");
            DropForeignKey("dbo.FNutritionalCharacteristics", "Id_korm", "dbo.Korm");
            DropIndex("dbo.Storage", new[] { "KormId" });
            DropIndex("dbo.Ration", new[] { "Id_task" });
            DropIndex("dbo.Ration", new[] { "Id_korm" });
            DropIndex("dbo.RationCow", new[] { "KormId" });
            DropIndex("dbo.RationCow", new[] { "MilkId" });
            DropIndex("dbo.NutritionalCategories", new[] { "Id_faza" });
            DropIndex("dbo.NNutritionalCharacteristics", new[] { "Id_korm" });
            DropIndex("dbo.NNutritionalCharacteristics", new[] { "Id_index" });
            DropIndex("dbo.NNutritionalCharacteristics", new[] { "Id_category" });
            DropIndex("dbo.FNutritionalCharacteristics", new[] { "Id_category" });
            DropIndex("dbo.FNutritionalCharacteristics", new[] { "Id_index" });
            DropIndex("dbo.FNutritionalCharacteristics", new[] { "Id_korm" });
            DropIndex("dbo.FNutritionalCharacteristics", new[] { "Id_task" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Storage");
            DropTable("dbo.Task");
            DropTable("dbo.Ration");
            DropTable("dbo.Milk");
            DropTable("dbo.RationCow");
            DropTable("dbo.Faza");
            DropTable("dbo.NutritionalCategories");
            DropTable("dbo.NNutritionalCharacteristics");
            DropTable("dbo.Korm");
            DropTable("dbo.FNutritionalCharacteristics");
            DropTable("dbo.CatalogIndexNutritional");
        }
    }
}
