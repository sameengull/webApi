using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace booksapi.models
{
    public class bookscontext : DbContext
    {
        public bookscontext(DbContextOptions<bookscontext> options)
            : base(options)
        {
        }

        public DbSet<booksitem> booksitems { get; set; }
    }
}



