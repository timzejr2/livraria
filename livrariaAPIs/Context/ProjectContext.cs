using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPIs.Models;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPIs.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
    }
}