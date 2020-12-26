using POS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace POS.DAL
{
    public class DataContext : DbContext
    {

        public DataContext() : base("Data Source=(localdb)\\MSSQLLOCALDB;Initial Catalog=POSv4;Integrated Security=True")
        {

        }

        //Add refrences to models
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public System.Data.Entity.DbSet<POS.Models.TransProd> TransProds { get; set; }
    }
}