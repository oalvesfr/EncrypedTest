using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EncrypedTest.Data
{
    public class EncrypedTestContext : DbContext
    {
        public EncrypedTestContext (DbContextOptions<EncrypedTestContext> options)
            : base(options)
        {
        }

        public DbSet<Test> Test { get; set; } = default!;
        public DbSet<TestJson> TestJson { get; set; } = default!;
        public DbSet<TesteTempo> TesteTempo { get; set; } = default!;
        public DbSet<TestAesJson> TestAesJson { get; set; } = default!;
        public DbSet<TestASCII> TestASCII { get; set; } = default!;
    }
}
