using EF_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_CRUD.Context
{
    public class ProductContext: DbContext 
    {
        public DbSet<Product> products { get; set; }

      
    }
}