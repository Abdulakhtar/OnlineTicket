using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace OnlineTicket.EntityFrameworkCore
{
    public static class OnlineTicketDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<OnlineTicketDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<OnlineTicketDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
