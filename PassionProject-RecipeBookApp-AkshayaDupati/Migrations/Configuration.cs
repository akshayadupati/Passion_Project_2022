namespace PassionProject_RecipeBookApp_AkshayaDupati.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PassionProject_RecipeBookApp_AkshayaDupati.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PassionProject_RecipeBookApp_AkshayaDupati.Models.ApplicationDbContext";
        }

        protected override void Seed(PassionProject_RecipeBookApp_AkshayaDupati.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
