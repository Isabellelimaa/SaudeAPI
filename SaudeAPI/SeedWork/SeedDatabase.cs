using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaudeAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaudeAPI.SeedWork
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SaudeContext(serviceProvider.GetRequiredService<DbContextOptions<SaudeContext>>()))
            {
                //if (context.InvestigationTags.Any())
                //{
                //    return;
                //}

                //context.InvestigationTags.AddRange(
                //    new Models.InvestigationTag
                //    {
                //        Abbreviation = "A1A",
                //        Name = "Alpha-1 Antitrypsin"
                //    },

                //    new Models.InvestigationTag
                //    {
                //        Abbreviation = "A1c",
                //        Name = "Hemoglobin A1c"
                //    },


                //    new Models.InvestigationTag
                //    {
                //        Abbreviation = "Alk Phos",
                //        Name = "Alkaline Phosphatase"
                //    }
                //    );
                context.SaveChanges();
            }
        }
    }
}
