using System.Threading.Tasks;
using OnlineTicket.Configuration.Dto;

namespace OnlineTicket.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
