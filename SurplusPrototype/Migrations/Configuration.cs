namespace SurplusPrototype.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SurplusPrototype.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SurplusPrototype.DataAccess.SurplusDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SurplusPrototype.DataAccess.SurplusDbContext";
        }

        protected override void Seed(SurplusPrototype.DataAccess.SurplusDbContext context)
        {
            var itemConditions = new List<ItemCondition>
            {
                new ItemCondition { Name = "Good" },
                new ItemCondition { Name = "Poor" },
                new ItemCondition { Name = "Needs repair" }
            };
            itemConditions.ForEach(c => context.ItemConditions.AddOrUpdate(x => x.Name, c));
            context.SaveChanges();

            var quantityDescriptions = new List<QuantityDescription>
            {
                new QuantityDescription { Name = "Each" },
                new QuantityDescription { Name = "Small lot" },
                new QuantityDescription { Name = "Large lot" }
            };
            quantityDescriptions.ForEach(d => context.QuantityDescriptions.AddOrUpdate(x => x.Name, d));
            context.SaveChanges();
        }
    }
}
