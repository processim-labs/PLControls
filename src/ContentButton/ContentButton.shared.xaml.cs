using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContentButton.FormsPlugin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ContentProperty("ButtonContent")]
    public partial class ContentButton : ContentView
    {
        public ContentButton()
        {
            InitializeComponent();
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public View ButtonContent
        {
            get => (View)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ContentButton), null, propertyChanged: (bindable, oldValue, newValue) => ((ContentButton)bindable).OnClickOrTouchedDownCommandPropertyChanged());
        public static readonly BindableProperty ButtonContentProperty = BindableProperty.Create(nameof(ButtonContent), typeof(View), typeof(ContentButton), propertyChanged: ButtonContentChanged);

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ContentButton), null, propertyChanged: (bindable, oldValue, newValie) => ((ContentButton)bindable).CommandCanExecuteChanged(bindable, EventArgs.Empty));

        private static void ButtonContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null && bindable != null)
            {
                if (bindable is ContentButton control && newValue is View newView)
                {
                    if (control.container != null)
                    {
                        control.container.Content = newView;
                    }
                }
            }
        }

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

        private async void Button_Pressed(object sender, EventArgs e)
        {
            if (container != null)
            {
                uint halfAnimationPeriod = 50;
                await container.FadeTo(0.5, halfAnimationPeriod);
                await container.FadeTo(1, halfAnimationPeriod);
            }
        }
    }
}