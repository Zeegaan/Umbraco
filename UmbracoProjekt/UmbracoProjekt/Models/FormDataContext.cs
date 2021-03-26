using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmbracoProjekt.Models;

namespace UmbracoProjekt.Models
{
    public class FormDataContext : DbContext
    {
        public virtual DbSet<Form> Forms { get; set; }
        public FormDataContext(DbContextOptions<FormDataContext> options) : base(options)
        {
            //Checking if database exist, if not, create it
            Database.EnsureCreated();
        }
    }
}
