using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using Newtonsoft.Json;

namespace MuOnlineCMS.Core.Configuration
{
    [Serializable]
    public class Config : INotifyPropertyChanged
    {
        private VersionType version;
        private string theme;

        private static Config conf;

        public static Config GetInstance()
        {
            // Singleton

            if (conf == null)
            {
                conf = new Config();
            }

            return conf;
        }

        public Config Load()
        {
            string jsonPath = HttpContext.Current.Server.MapPath("~/config.json");
            if (!File.Exists(jsonPath))
            {
                Theme = "Default";
                Version = VersionType.NotSet;
                Save();
            }

            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(jsonPath));
        }

        private void Save()
        {
            string jsonPath = HttpContext.Current.Server.MapPath("~/config.json");
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(this));
        }


        public string Theme
        {
            get => this.theme;
            set
            {
                if (value == this.theme) return;
                this.theme = value;
                OnPropertyChanged();
            }
        }

        public VersionType Version
        {
            get => this.version;
            set
            {
                if (value == this.version) return;
                this.version = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Save();
        }
    }
}