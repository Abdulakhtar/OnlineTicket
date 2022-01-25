using Abp.Application.Services.Dto;

namespace OnlineTicket.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

