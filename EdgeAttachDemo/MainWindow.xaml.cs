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

namespace EdgeAttachDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _workAreaWidth = SystemParameters.WorkArea.Width;
        private double _workAreaHeight = SystemParameters.WorkArea.Height;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
            (bool f, double left, double top) values = CheckPositonInEdge(this.Left, this.Top, this.Width, this.Height);
            if (values.f)
            {
                this.Left = values.left;
                this.Top = values.top;
            }
        }
        public (bool f, double left, double top) CheckPositonInEdge(double left, double top, double width, double height)
        {
            var f = false;

            if (left < 0)
            {
                left = 0;
                f = true;
            }
            if (top < 0)
            {
                top = 0;
                f = true;
            }
            if (left + width > _workAreaWidth)
            {
                left = _workAreaWidth - width;
                f = true;

            }
            if (top + height > _workAreaHeight)
            {
                top = _workAreaHeight - height;
                f = true;
            }
            return (f, left, top);

        }
    }
}
