using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ListAppFinal.Droid.ImageLoadingExtentions
{
    public static class LoadEmbeddedResourceExtension
    {
        private static Assembly _assembly = null;

        public static void Init(Assembly assembly)
        {
            _assembly = assembly;
        }

        public static System.IO.Stream Load(string resourceName)
        {
            if (_assembly == null)
                throw new Exception("Init needs to be called prior to calling Load");

            return _assembly.GetManifestResourceStream(resourceName);
        }
    }
}