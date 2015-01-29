using SurplusPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurplusPrototype.DataAccess
{
    public class SurplusDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SurplusDbContext>
    {
        protected override void Seed(SurplusDbContext context)
        {
            var itemConditions = new List<ItemCondition>
            {
                new ItemCondition { Name = "Good" },
                new ItemCondition { Name = "Poor" },
                new ItemCondition { Name = "Needs repair" }
            };
            itemConditions.ForEach(c => context.ItemConditions.Add(c));
            context.SaveChanges();

            var quantityDescriptions = new List<QuantityDescription>
            {
                new QuantityDescription { Name = "Each" },
                new QuantityDescription { Name = "Small lot" },
                new QuantityDescription { Name = "Large lot" }
            };
            quantityDescriptions.ForEach(d => context.QuantityDescriptions.Add(d));
            context.SaveChanges();

            base.Seed(context);
        }

    }
}