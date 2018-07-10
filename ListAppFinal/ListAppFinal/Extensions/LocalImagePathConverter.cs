using System;
using System.Globalization;
using System.Reflection;
using Prism.Logging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListAppFinal.Extensions
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
}