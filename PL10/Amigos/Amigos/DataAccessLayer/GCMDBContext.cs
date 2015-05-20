using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Amigos.DataAccessLayer
{
    public class GCMDBContext : DbContext
    {
        public DbSet<Amigos.Models.GCMModel> GCMs { get; set; }
    }
}
