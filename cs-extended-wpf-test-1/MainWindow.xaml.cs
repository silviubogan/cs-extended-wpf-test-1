using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cs_extended_wpf_test_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFlowViewAnchorable.Float();
            MyFlowViewAnchorable.IsVisible = false;
            MyFlowViewAnchorable.AddToLayout(MyDockingManager,
                Xceed.Wpf.AvalonDock.Layout.AnchorableShowStrategy.Top);
            MyDataGridAnchorable.AddToLayout(MyDockingManager,
                Xceed.Wpf.AvalonDock.Layout.AnchorableShowStrategy.Bottom);
        }
    }
}
