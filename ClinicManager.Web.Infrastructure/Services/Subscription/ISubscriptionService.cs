using ClinicManager.Shared.DTO_s;
using ClinicManager.Shared.Wrappers;

namespace ClinicManager.Web.Infrastructure.Services.Subscription
{
    public interface ISubscriptionService
    {
        Task<IResult<List<SubscriptionDTO>>> GetAll();

        Task<IResult<SubscriptionDTO>> GetById(int id);

        Task<IResult<List<SubscriptionDTO>>> GetSubscriptionByChecked();

        Task<IResult<int>> SaveAsync(SubscriptionDTO request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<PaginatedResult<SubscriptionDTO>> GetAllSubscriptionsTable(int pageNumber, int pageSize, string searchString, string[] orderBy);

        Task<PaginatedResult<SubscriptionDTO>> GetAllCheckedSubscriptionsTable(int pageNumber, int pageSize, string searchString, string[] orderBy);
    }
}
