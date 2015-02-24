namespace SurplusPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IX_FixedAssetNumber : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FixedAsset", "AssetNumber");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FixedAsset", new[] { "AssetNumber" });
        }
    }
}
