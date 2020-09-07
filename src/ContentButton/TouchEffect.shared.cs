using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContentButton.FormsPlugin
{
    public class TouchEffect : RoutingEffect
    {
        public Color Color { get; set; }
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        public TouchEffect() : base($"ContentButton.FormsPlugin.TouchEffect")
        {
        }
    }
}

