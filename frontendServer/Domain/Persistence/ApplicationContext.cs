using frontendServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frontendServer.Domain.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
    }
}