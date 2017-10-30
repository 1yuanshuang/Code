using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;

namespace Smlant
{
    public class BootSttaper : UnityBootstrapper
    {
        #region ---Parm---

        private IModuleManager _moduleManager;
        private ModuleCatalog moduleCatalog;

        #endregion

        protected override System.Windows.DependencyObject CreateShell()
        {
            return new MainWindow();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Closing += new System.ComponentModel.CancelEventHandler((s, e) =>
            {
                App.Current.Shutdown();
            });
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            moduleCatalog = (ModuleCatalog)this.ModuleCatalog;

            moduleCatalog.AddModule(typeof(Smlant.StartUpModule));
        }
    }  
}
