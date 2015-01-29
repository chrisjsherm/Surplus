namespace SurplusPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCondition",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuantityDescription",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurplusRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VTBarcode = c.String(maxLength: 8),
                        Description = c.String(nullable: false, maxLength: 50),
                        Manufacturer = c.String(maxLength: 35),
                        Model = c.String(maxLength: 30),
                        SerialNumber = c.String(maxLength: 40),
                        Quantity = c.Int(nullable: false),
                        QuantityDescriptionId = c.Guid(nullable: false),
                        EstimatedValue = c.Int(),
                        ItemConditionId = c.Guid(nullable: false),
                        AccountingFund = c.String(nullable: false, maxLength: 6),
                        DepartmentNumber = c.String(nullable: false),
                        MailCode = c.String(maxLength: 4),
                        ItemLocation = c.String(nullable: false),
                        ContactName = c.String(nullable: false),
                        ContactPhone = c.String(nullable: false),
                        AuthorizerName = c.String(nullable: false),
                        AdditionalDetails = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCondition", t => t.ItemConditionId, cascadeDelete: true)
                .ForeignKey("dbo.QuantityDescription", t => t.QuantityDescriptionId, cascadeDelete: true)
                .Index(t => t.QuantityDescriptionId)
                .Index(t => t.ItemConditionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurplusRequest", "QuantityDescriptionId", "dbo.QuantityDescription");
            DropForeignKey("dbo.SurplusRequest", "ItemConditionId", "dbo.ItemCondition");
            DropIndex("dbo.SurplusRequest", new[] { "ItemConditionId" });
            DropIndex("dbo.SurplusRequest", new[] { "QuantityDescriptionId" });
            DropTable("dbo.SurplusRequest");
            DropTable("dbo.QuantityDescription");
            DropTable("dbo.ItemCondition");
        }
    }
}
