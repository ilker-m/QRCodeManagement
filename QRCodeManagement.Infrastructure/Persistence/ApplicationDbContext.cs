using Microsoft.EntityFrameworkCore;
using QRCodeManagement.Domain.Entities;
using System.Collections.Generic;

namespace QRCodeManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<QRCode> QRCodes => Set<QRCode>();
    }
}
