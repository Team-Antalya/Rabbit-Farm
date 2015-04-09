using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using RabbitFarm.Models;

namespace RabbitFarm.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public const string ConnectionStringSQL = "Server=.;Database=RabbitFarm;Integrated Security=True;";
        public const string ConnectionStringAzure = "Server=ibz4rymk74.database.windows.net;Database=Antalya;Persist Security Info=True;User ID=antalya;Password=Parola123;";
        public const string ConnectionStringLocalDB = "Server=(localdb)\v11.0;Database=RabbitFarm;Integrated Security=True;";
        public ApplicationDbContext()
            : base(ConnectionStringSQL, throwIfV1Schema: false)
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
