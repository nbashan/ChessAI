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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace PL.View
{
    /// <summary>
    /// Interaction logic for SquareUC.xaml
    /// </summary>
    public partial class SquareUC : UserControl
    {
        public string ButtonImage
        {
            get { return (string)GetValue(ButtonImageProperty); }
            set { SetValue(ButtonImageProperty, value); }
        }


        public static readonly DependencyProperty ButtonImageProperty =
        DependencyProperty.Register("ButtonImage",
             typeof(string), typeof(SquareUC),
             new FrameworkPropertyMetadata(OnButtonImageSourcePathChanged));


        private static void OnButtonImageSourcePathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StreamResourceInfo streamInfo = Application.GetResourceStream(new Uri(e.NewValue as string, UriKind.Relative));
            BitmapFrame temp2 = BitmapFrame.Create(streamInfo.Stream);
            var brush1 = new ImageBrush();
            brush1.ImageSource = temp2;

            ((SquareUC)d).myButton.Background = brush1;

        }
        public SquareUC()
        {
            InitializeComponent();
        }
    }
}
