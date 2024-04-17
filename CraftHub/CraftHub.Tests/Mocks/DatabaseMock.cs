using CraftHub.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftHub.Tests.Mocks
{
    public class DatabaseMock
    {
        public static CraftHubDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<CraftHubDbContext>()
                    .UseInMemoryDatabase("CraftHubInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new CraftHubDbContext(dbContextOptions, false);
            }
        }
    }
}
