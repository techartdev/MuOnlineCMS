using System.Configuration;
using MuOnlineCMS.Core.Configuration;
using MuOnlineCMS.Web;

namespace MuOnlineCMS.Web
{
    public class WebConfig
    {
        public static Config Config { get; set; }

        public static void Initialize()
        {
            Config = Config.GetInstance();
            Config =  Config.Load();
        }
    }
}
