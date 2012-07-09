using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Context;
using Spring.Context.Support;

namespace TaoMeetting.Utility
{
    public static class SpringHelper
    {
        private static readonly IApplicationContext _applicationContext;

        static SpringHelper()
        {
            _applicationContext = ContextRegistry.GetContext();
        }

        public static IApplicationContext ApplicationContext
        {
            get { return _applicationContext; }
        }
    }
}
