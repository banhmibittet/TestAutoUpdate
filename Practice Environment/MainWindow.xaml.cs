using KAutoHelper;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

namespace Practice_Environment
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

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return new Bitmap(bitmap);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var screen = CaptureHelper.CaptureScreen();
            screen.Save("mainScreen.PNG");

            //var subBitmap = ImageScanOpenCV.GetImage("template.PNG");
            var bitmapImage = new BitmapImage(new Uri(@"pack://application:,,,/Images/captcha.png", UriKind.Absolute));
            var subBitmap = BitmapImage2Bitmap(bitmapImage);

            var resBitmap = ImageScanOpenCV.Find((Bitmap)screen, subBitmap);
            if (resBitmap != null)
            {
                MessageBox.Show("OK");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var a = File.ReadAllText("test");
            MessageBox.Show(a);
        }
    }
}
