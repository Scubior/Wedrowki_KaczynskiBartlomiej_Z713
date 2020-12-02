using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Wedrowki.Models
{
    public class WedrowkiDB : DbContext
    {
        public DbSet<WedrowkaModel> Piesze_Wedrowki { get; set; }
    }
}