using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace Smlant
{
    public class StartUpModule:IModule
    {
        private IRegionManager _regionManager;

        public StartUpModule()
        {
            _regionManager = (IRegionManager)ServiceLocator.Current.GetService(typeof(IRegionManager));
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ToolkitRegion", typeof(StartViews.MainContent));
            _regionManager.RegisterViewWithRegion("MenuRegion", typeof(StartViews.MenuView));
        }
    }
}
