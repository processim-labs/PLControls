using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
    }
}