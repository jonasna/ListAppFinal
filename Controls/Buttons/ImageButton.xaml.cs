using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Controls.Buttons
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageButton : ContentView, IButtonController
	{
	    private const int DefaultCornerRadius = -1;
	    private const int DefaultPadding = 0;

        public ImageButton ()
		{
			InitializeComponent ();
		    Padding = DefaultPadding;
		}

	    public static readonly BindableProperty SourceProperty = BindableProperty.Create("Source", typeof(ImageSource), typeof(ImageButton), null, BindingMode.Default,
	            propertyChanged: (bindable, oldValue, newValue) =>
	            {
	                var control = (ImageButton) bindable;
	                control.Image.Source = (ImageSource) newValue;
	            });

	    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(int), typeof(ImageButton), DefaultCornerRadius);

	    public static readonly BindableProperty HasShadowProperty = BindableProperty.Create("HasShadow", typeof(bool), typeof(Frame), true);

        public ImageSource Source
	    {
	        get => (ImageSource)GetValue(SourceProperty);
	        set => SetValue(SourceProperty, value);
	    }

	    public int CornerRadius
	    {
	        get => (int)GetValue(CornerRadiusProperty);
	        set => SetValue(CornerRadiusProperty, value);
	    }

	    public bool HasShadow
	    {
	        get => (bool) GetValue(HasShadowProperty);
	        set => SetValue(HasShadowProperty, value);
	    }

        #region ButtonController

	    public event EventHandler Clicked;

	    public event EventHandler Pressed;

	    public event EventHandler Released;

	    public void SendClicked()
	    {
	        if (IsEnabled)
	        {
	            Clicked?.Invoke(this, EventArgs.Empty);
            }
	    }

	    public async void SendPressed()
	    {
	        if (IsEnabled)
	        {
	            await Frame.ScaleTo(0.8, 250U, Easing.Linear);
                Pressed?.Invoke(this, EventArgs.Empty);
	        }
	    }

	    public async void SendReleased()
	    {
	        if (IsEnabled)
	        {
	            await Frame.ScaleTo(1, 250U, Easing.Linear);
                Released?.Invoke(this, EventArgs.Empty);
	        }
	    }

        #endregion

    }
}