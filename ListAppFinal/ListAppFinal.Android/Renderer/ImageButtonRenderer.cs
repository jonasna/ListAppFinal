using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Controls.Buttons;
using ListAppFinal.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Xamarin.Forms.Button;
using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;
using ImageButton = Controls.Buttons.ImageButton;
using View = Xamarin.Forms.View;

[assembly: ExportRenderer(typeof(ImageButton), typeof(ImageButtonRenderer))]
namespace ListAppFinal.Droid.Renderer
{
    public class ImageButtonRenderer : ViewRenderer<ImageButton, Android.Views.View>
    {

        private bool _isDisposed;

        public ImageButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ImageButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {

            }

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var imageView = CreateNativeControl();

                    imageView.SetOnClickListener(ImageButtonOnClickListener.Instance.Value);
                    imageView.SetOnTouchListener(ImageButtonOnTouchListener.Instance.Value);
                    imageView.Tag = this;

                    SetNativeControl(imageView);                
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            _isDisposed = true;

            if (disposing)
            {
                if (Control != null)
                {
                    Control.SetOnClickListener(null);
                    Control.SetOnTouchListener(null);
                    Control.Tag = null; 
                }
            }

            base.Dispose(disposing);
        }

        protected override Android.Views.View CreateNativeControl()
        {
            return new Android.Views.View(Context);
        }
    }

    internal class ImageButtonOnClickListener : Java.Lang.Object, Android.Views.View.IOnClickListener
    {
        private ImageButtonOnClickListener(){}

        public static readonly Lazy<ImageButtonOnClickListener> Instance = new Lazy<ImageButtonOnClickListener>(() => new ImageButtonOnClickListener());

        public void OnClick(Android.Views.View v)
        {
            if (v.Tag is ImageButtonRenderer nativeControl)
            {
                if (nativeControl.Element is IButtonController imgButton)
                {
                    imgButton.SendClicked();;
                }
            }
        }
    }

    internal class ImageButtonOnTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        private ImageButtonOnTouchListener() { }

        public static readonly Lazy<ImageButtonOnTouchListener> Instance = new Lazy<ImageButtonOnTouchListener>(() => new ImageButtonOnTouchListener());

        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                if (v.Tag is ImageButtonRenderer nativeControl)
                {
                    if (nativeControl.Element is IButtonController imgButton)
                    {
                        imgButton.SendPressed();
                    }
                }

            }else if (e.Action == MotionEventActions.Up)
            {
                if (v.Tag is ImageButtonRenderer nativeControl)
                {
                    if (nativeControl.Element is IButtonController imgButton)
                    {
                        imgButton.SendReleased();
                    }

                }
            }

            return false;
        }
    }
}