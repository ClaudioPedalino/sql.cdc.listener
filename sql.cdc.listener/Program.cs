using sql.cdc.listener.Config;
using System.Threading.Tasks;

namespace sql.cdc.listener
{
    class Program
    {
        static Task Main(string[] args)
        {
            var appsettings = ConfigHelper.GetAppsettings();
            ListenerService.Start(appsettings.CDCListenerDb);
            return Task.CompletedTask;
        }
    }
}
