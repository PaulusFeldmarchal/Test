using adminServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminServer.Domain.Persistence
{
    class TestContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public TestContext(DbContextOptions<TestContext> options)
            : base(options) { }
    }
}