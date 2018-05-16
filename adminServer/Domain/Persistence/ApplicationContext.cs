using adminServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminServer.Domain.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
    }
}