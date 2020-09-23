using Android.Content;
using Android.OS;
using Android.Text;
using PLControls.FormsPlugin;
using PLControls.FormsPlugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(JustifiedLabel), typeof(JustifiedLabelRenderer))]
namespace PLControls.FormsPlugin.Droid
{
    public class JustifiedLabelRenderer : LabelRenderer
    {
        public JustifiedLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    Control.JustificationMode = JustificationMode.InterWord;
                }
            }
        }
    }
}
