using System.Threading.Tasks;

namespace WebEndpoints.WebApiEndpoint.Common
{
  public static class TaskExtensions
  {
    public static Task<object> ToTaskOfObject<T>(this Task<T> task)
    {
      return task.ContinueWith(t => (object)t.Result);
    }
  }
}
