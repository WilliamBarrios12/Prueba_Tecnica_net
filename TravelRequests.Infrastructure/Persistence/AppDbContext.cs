using Microsoft.EntityFrameworkCore;
using TravelRequests.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRequests.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TravelRequest> TravelRequests { get; set; }
        public DbSet<PasswordResetCode> PasswordResetCodes { get; set; }
    }
}
