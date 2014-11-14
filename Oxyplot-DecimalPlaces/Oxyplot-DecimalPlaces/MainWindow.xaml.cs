namespace Oxyplot_DecimalPlaces
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
        }

        public MainWindowViewModel ViewModel { get; private set; }
    }
}