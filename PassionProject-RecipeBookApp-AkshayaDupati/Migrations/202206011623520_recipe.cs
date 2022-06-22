﻿namespace PassionProject_RecipeBookApp_AkshayaDupati.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(),
                        RecipeDescription = c.String(),
                    })
                .PrimaryKey(t => t.RecipeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recipes");
        }
    }
}
