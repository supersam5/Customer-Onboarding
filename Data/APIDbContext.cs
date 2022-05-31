using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer_Onboarding.Models;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

namespace Customer_Onboarding.Data
{
    public class APIDbContext:  DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options)
            : base(options)
        {
            
        }

       
        public DbSet<State> States { get; set; }
        public DbSet<LocalGovtArea> LocalGovtAreas { get; set; }
        public DbSet<Customer> Customers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<StatesAndLgas> data = new List<StatesAndLgas>();
            using (StreamReader r = new StreamReader("StatesAndLgas.json"))
            {
                string json = r.ReadToEnd();
                int stateCount = 1;
                int lgaCount = 1;
                data = JsonSerializer.Deserialize<List<StatesAndLgas>>(json);
                Debug.Write(data.First());
                
                foreach(StatesAndLgas statedoc in data)
                {
                    List<LocalGovtArea> lgas = new List<LocalGovtArea>();
                    foreach (string lga in statedoc.lgas)
                        {
                           /* lgas.Add(
                               new LocalGovtArea
                               {
                                   Id = lgaCount,
                                   Name = lga,
                                   StateId = stateCount
                               }
                           );*/
                            modelBuilder.Entity<LocalGovtArea>().HasData(
                                new LocalGovtArea
                                {
                                    Id = lgaCount,
                                    Name = lga,
                                    StateId = stateCount
                                }
                         );
                        lgaCount++;
                        }
                    modelBuilder.Entity<State>().HasData(
                    new State
                            {
                                Id = stateCount,
                                Name = statedoc.state,
                                //LGAs = lgas
                            }
                        );
                    stateCount++;
                }
            }
            
        }

    }
}
            
        
