
namespace ClinicManager.Web.Infrastructure.Extensions
{
    public static class TaskExtensions
    {
        public static async void Await(this Task task, Action completedCallBack, Action<Exception> errorCallBack)
        {
            try
            {
                await task;
                completedCallBack?.Invoke();
            }
            catch (Exception ex)
            {
                errorCallBack.Invoke(ex);
            }
        }
    }
}
