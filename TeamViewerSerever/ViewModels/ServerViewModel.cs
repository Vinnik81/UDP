using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TeamViewerSerever.ViewModels
{
    class ServerViewModel: ViewModelBase
    {
        private string ip = "127.0.0.1";
        public string Ip { get => ip; set => Set(ref ip, value); }
        private int port = 8080;
        public int Port { get => port; set => Set(ref port, value); }
        private string info;
        public string Info { get => info; set => Set(ref info, value); }

        private RelayCommand startCommand;
        public RelayCommand StartCommand => startCommand ??= new RelayCommand(
            () =>
            {
                Task.Run(() =>
                {
                    UdpClient udpClient = new UdpClient();
                    while (true)
                    {
                        try
                        {
                            byte[] data = CaptureScreen();
                            byte[] chunk = new byte[10000];
                            int bytesCount = 0;

                            using (var memory = new MemoryStream(data))
                            {
                                while ((bytesCount = memory.Read(chunk, 0, 10000)) != 0)
                                {
                                    udpClient.Send(chunk, bytesCount, Ip, Port);
                                }
                            }

                            udpClient.Send(new byte[] { 1, 2, 3 }, 3, Ip, Port);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                });
            });

        public byte[] CaptureScreen()
        {
            var width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            var height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            using (var memory = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(0, 0, 0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size);
                    Bitmap objBitmap = new Bitmap(bmp, width, height);
                    objBitmap.Save(memory, ImageFormat.Jpeg);
                }

                return memory.GetBuffer();
            }
        }
    }
}
