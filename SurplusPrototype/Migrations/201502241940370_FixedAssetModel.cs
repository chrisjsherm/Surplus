namespace SurplusPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedAssetModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FixedAsset",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FixedAsset");
        }
    }
}
