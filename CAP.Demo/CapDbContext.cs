using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CAP.Demo
{
    public class CapDbContext:DbContext
    {
        public CapDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
