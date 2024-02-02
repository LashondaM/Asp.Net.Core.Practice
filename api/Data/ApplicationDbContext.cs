using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        /* DbSet -- I'm going to grab something out of the DB and you need to do something with it 
        Deferred execution DbSets also manipulates the whole entire table */
        public DbSet<Stock> Stock {get; set;}
        public DbSet<Comment> Comment {get; set;}
    }
}

// the ApplicationDbContext will allow us to access tables
// base is like typing DbContext() but you can't do that in contructors, so you type base
// We have our own DbContext and base will pass it up into the inherited DbContext