using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace Music_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string ImgPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString()}\\Images\\MusicIcon.jpg";
            Musicimg.Source = new BitmapImage(new Uri(ImgPath));
        }
        MediaPlayer mediaPlayer = new MediaPlayer();
        string filename;
        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
        private void BT_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDilaog = new OpenFileDialog
            {
                Multiselect = true,
                DefaultExt = ".mp3"
            };
            bool? dialogOk = fileDilaog.ShowDialog();
            if(dialogOk == true)
            {
                filename = fileDilaog.FileName;
                TBFileName.Text = fileDilaog.SafeFileName;
                mediaPlayer.Open(new Uri(filename));
            }
        }

        private void BT_Click_PLay(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void BT_Click_Pause(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void BT_Click_Stop(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        //private void BT_Click_VPlus(object sender, RoutedEventArgs e)
        //{
        //    mediaPlayer.Volume += 5;
        //}

        //private void BT_Click_VMinus(object sender, RoutedEventArgs e)
        //{
        //    mediaPlayer.Volume -= 5;
        //}
    }
}
