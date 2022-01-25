using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using OnlineTicket.Authorization.Roles;
using OnlineTicket.Authorization.Users;
using OnlineTicket.MultiTenancy;
using OnlineTicket.Students;

namespace OnlineTicket.EntityFrameworkCore
{
    public class OnlineTicketDbContext : AbpZeroDbContext<Tenant, Role, User, OnlineTicketDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Student> StudentData { get; set; }

        public OnlineTicketDbContext(DbContextOptions<OnlineTicketDbContext> options)
            : base(options)
        {
        }
    }
}
