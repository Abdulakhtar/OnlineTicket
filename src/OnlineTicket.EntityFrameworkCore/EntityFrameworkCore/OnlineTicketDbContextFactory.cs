using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnlineTicket.Configuration;
using OnlineTicket.Web;

namespace OnlineTicket.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class OnlineTicketDbContextFactory : IDesignTimeDbContextFactory<OnlineTicketDbContext>
    {
        public OnlineTicketDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OnlineTicketDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            OnlineTicketDbContextConfigurer.Configure(builder, configuration.GetConnectionString(OnlineTicketConsts.ConnectionStringName));

            return new OnlineTicketDbContext(builder.Options);
        }
    }
}
