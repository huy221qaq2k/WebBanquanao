﻿namespace WebThoiTrang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Post", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Post", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Post", "SeoTiltle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Post", "SeoDescrpition", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Post", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "Alias", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.tb_Product", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "SeoTiltle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "SeoDescrpition", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Product", "SeoKeywords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoDescrpition", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoTiltle", c => c.String());
            AlterColumn("dbo.tb_Product", "Image", c => c.String());
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String());
            AlterColumn("dbo.tb_Product", "Alias", c => c.String());
            AlterColumn("dbo.tb_Post", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tb_Post", "SeoDescrpition", c => c.String());
            AlterColumn("dbo.tb_Post", "SeoTiltle", c => c.String());
            AlterColumn("dbo.tb_Post", "Image", c => c.String());
            AlterColumn("dbo.tb_Post", "Alias", c => c.String());
        }
    }
}
