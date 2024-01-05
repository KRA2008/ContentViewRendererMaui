using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;
using View = Android.Views.View;

namespace ContentViewRendererMaui.Platforms.Android
{
    public class MyContentViewRenderer : ViewRenderer<MyContentView, View>, 
        TextureView.ISurfaceTextureListener
    {
        public MyContentViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MyContentView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var textureView = new TextureView(Context);
                textureView.SurfaceTextureListener = this;

                AddView(textureView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            System.Diagnostics.Debug.WriteLine("### the SurfaceTexture has become available!");
            Debugger.Break();
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
        }
    }
}
