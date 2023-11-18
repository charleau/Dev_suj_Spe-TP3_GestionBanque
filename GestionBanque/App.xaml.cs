using Autofac;
using GestionBanque.ViewModels.Interfaces;
using GestionBanque.ViewModels;
using GestionBanque.Views;
using System.Windows;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace GestionBanque
{

    /*
        2 banque view model
     -  1 client sql lite dataservice
     -  1 compte sql lite dataservice
     -  2 client model
     -- 2 compte model
     */
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var config = new ConfigurationBuilder();
            // https://autofac.readthedocs.io/en/latest/configuration/xml.html
            config.AddJsonFile("di.json");

            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            FournisseurDI.Container = builder.Build();
        }
    }
}
