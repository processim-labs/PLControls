//using Android.Animation;
//using Android.Content;
//using Android.Content.Res;
//using Android.Graphics;
//using Android.Graphics.Drawables;
//using Android.OS;
//using Android.Views;
//using Android.Widget;
//using ContentButton.FormsPlugin.Droid;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
//using Color = Android.Graphics.Color;
//using View = Android.Views.View;
//using FrameRenderer = Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer;

//[assembly: ExportRenderer(typeof(ContentButton.FormsPlugin.ContentButton), typeof(ContentButtonRenderer))]
//namespace ContentButton.FormsPlugin.Droid
//{
//    public class ContentButtonRenderer : FrameRenderer
//    {
//        public ContentButtonRenderer(Context context) : base(context)
//        {
//        }

//        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
//        {
//            base.OnElementChanged(e);

//            if (e.NewElement != null && Element != null)
//            {
//                UpdateCornerRadius();
//            }
//        }

//        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
//        {
//            base.OnElementPropertyChanged(sender, e);

//            if (e.PropertyName == nameof(ContentButton.CornerRadius) ||
//                e.PropertyName == nameof(ContentButton))
//            {
//                UpdateCornerRadius();
//            }
//        }

//        private void UpdateCornerRadius()
//        {
//            if (Control.Background is GradientDrawable backgroundGradient)
//            {
//                var cornerRadius = (Element as ContentButton)?.CornerRadius;
//                if (!cornerRadius.HasValue)
//                {
//                    return;
//                }

//                var topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
//                var topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
//                var bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
//                var bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

//                var cornerRadii = new[]
//                {
//                    topLeftCorner,
//                    topLeftCorner,

//                    topRightCorner,
//                    topRightCorner,

//                    bottomRightCorner,
//                    bottomRightCorner,

//                    bottomLeftCorner,
//                    bottomLeftCorner,
//                };

//                backgroundGradient.SetCornerRadii(cornerRadii);
//            }
//        }
//    }
//}
