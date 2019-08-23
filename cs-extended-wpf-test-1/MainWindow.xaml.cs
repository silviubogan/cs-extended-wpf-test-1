using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
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
using System.Xml;

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

        internal Xceed.Wpf.AvalonDock.Layout.Serialization.XmlLayoutSerializer Serializer;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Serializer = new Xceed.Wpf.AvalonDock.Layout.Serialization.XmlLayoutSerializer(MyDockingManager);

            using (StringWriter writer = new StringWriter())
            {
                Serializer.Serialize(writer);

                string xml = writer.ToString();

                XElement doc = XElement.Parse(xml);

                XElement flowViewEl = doc
                    .Descendants()
                    .Where(el =>
                    {
                        return el.Attribute(XName.Get("ContentId"))?.Value == "MyFlowViewAnchorable";
                    })
                    .First();

                flowViewEl.Remove();

                doc.Elements(XName.Get("RootPanel"))
                    .Descendants(XName.Get("LayoutAnchorablePane"))
                    .First()
                    .Add(flowViewEl);

                using (StringReader reader = new StringReader(doc.ToString()))
                {
                    Serializer.Deserialize(reader);
                }

                var la = MyDockingManager.FindName("MyFlowViewAnchorable") as Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable;

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    la.IsActive = true;
                }));
            }
        }
    }
}
