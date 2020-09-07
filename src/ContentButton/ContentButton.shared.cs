using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Linq;

namespace ContentButton.FormsPlugin
{
    [DesignTimeVisible(true)]
    [Preserve()]
    [ContentProperty("Content")]
    public class ContentButton : Frame
    {
        private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();


        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public ContentButton()
        {
            // MK Clearing default values (e.g. on iOS it's 5)
            base.CornerRadius = 0;
        }

        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(ContentButton), typeof(CornerRadius), typeof(ContentButton));


        public double BorderWidth
        {
            get => (double)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(ContentButton), 0.0);
        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(ContentButton), Color.Black);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ContentButton), null, propertyChanged: (bindable, oldValue, newValue) => ((ContentButton)bindable).OnClickOrTouchedDownCommandPropertyChanged());

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ContentButton), null, propertyChanged: (bindable, oldValue, newValie) => ((ContentButton)bindable).CommandCanExecuteChanged(bindable, EventArgs.Empty));


        protected void CommandCanExecuteChanged(object sender, EventArgs e)
        {
            bool? canExecuteClick = Command?.CanExecute(CommandParameter);
            IsEnabled = canExecuteClick ?? false;
        }

        protected void OnClickOrTouchedDownCommandPropertyChanged()
        {
            if (Command != null)
                Command.CanExecuteChanged += CommandCanExecuteChanged;
            CommandCanExecuteChanged(this, EventArgs.Empty);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //Effects.Add(new TouchEffect());
            //var effect = (TouchEffect)Effects.FirstOrDefault(e => e is TouchEffect);

            if (propertyName == CommandProperty.PropertyName)
            {
                tapGestureRecognizer.Command = Command;
                tapGestureRecognizer.CommandParameter = CommandParameter;
                GestureRecognizers.Add(tapGestureRecognizer);
            }
            //if (propertyName == TouchEffectColorProperty.PropertyName)
            //{
            //    if (effect != null)
            //    {
            //        ((TouchEffect)Effects.FirstOrDefault(e => e is TouchEffect)).Color = TouchEffectColor;
            //    }
            //}
            base.OnPropertyChanged(propertyName);
        }
        public Color TouchEffectColor
        {
            get => (Color)GetValue(TouchEffectColorProperty);
            set => SetValue(TouchEffectColorProperty, value);
        }

        public static readonly BindableProperty TouchEffectColorProperty = BindableProperty.Create(nameof(TouchEffectColor), typeof(Color), typeof(ContentButton), Color.Default);
    }
}
