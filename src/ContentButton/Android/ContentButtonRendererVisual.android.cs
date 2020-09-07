//using Android.Graphics;
//using Android.Graphics.Drawables;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//namespace ContentButton.FormsPlugin.Droid
//{
//    public static class ContentButtonRendererVisual
//    {
//        public static void UpdateBackground(ContentButton touchView, Android.Views.View view)
//        {
//            var borderWidth = touchView.BorderWidth;
//            var context = view.Context;

//            GradientDrawable strokeDrawable = null;

//            if (borderWidth > 0)
//            {
//                strokeDrawable = new GradientDrawable();
//                strokeDrawable.SetColor(touchView.BackgroundColor.ToAndroid());

//                strokeDrawable.SetStroke((int)context.ToPixels(borderWidth), touchView.BorderColor.ToAndroid());
//                strokeDrawable.SetCornerRadius(context.ToPixels(touchView.CornerRadius));
//            }

//            var backgroundDrawable = new GradientDrawable();
//            backgroundDrawable.SetColor(touchView.BackgroundColor.ToAndroid());
//            backgroundDrawable.SetCornerRadius(context.ToPixels(touchView.CornerRadius));

//            if (strokeDrawable != null)
//            {
//                var ld = new LayerDrawable(new Drawable[] { strokeDrawable, backgroundDrawable });
//                ld.SetLayerInset(1, (int)context.ToPixels(borderWidth), (int)context.ToPixels(borderWidth), (int)context.ToPixels(borderWidth), (int)context.ToPixels(borderWidth));
//                view.Background = ld;
//            }
//            else
//            {
//                view.Background = backgroundDrawable;
//            }

//            view.SetPadding(
//                (int)context.ToPixels(borderWidth + touchView.Padding.Left),
//                (int)context.ToPixels(borderWidth + touchView.Padding.Top),
//                (int)context.ToPixels(borderWidth + touchView.Padding.Right),
//                (int)context.ToPixels(borderWidth + touchView.Padding.Bottom));
//        }

//        static double ThickestSide(this Thickness t)
//        {
//            return new double[] {
//                t.Left,
//                t.Top,
//                t.Right,
//                t.Bottom
//            }.Max();
//        }

//        public static void SetClipPath(this ContentButtonRenderer renderer, Canvas canvas)
//        {
//            var clipPath = new Path();
//            var radius = renderer.Context.ToPixels(renderer.Element.CornerRadius) - renderer.Context.ToPixels((float)renderer.Element.Padding.ThickestSide());

//            var w = renderer.Width;
//            var h = renderer.Height;

//            clipPath.AddRoundRect(new RectF(
//                renderer.ViewGroup.PaddingLeft,
//                renderer.ViewGroup.PaddingTop,
//                w - renderer.ViewGroup.PaddingRight,
//                h - renderer.ViewGroup.PaddingBottom),
//                radius,
//                radius,
//                Path.Direction.Cw);

//            canvas.ClipPath(clipPath);
//        }
//    }
//}
