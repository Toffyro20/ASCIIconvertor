using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ASCIIconvertor
{
    internal class Program
    {
        private const double WID = 2.3;
        private const int m_W = 200;

        [STAThread]
        static void Main(string[] args)
        {
           
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.png; *.jpg; *.JPEG"
            };

            
            while (true)
            {
                Console.ReadLine();
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;

                Console.Clear();

                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = ResizeBitmap(bitmap);
                bitmap.toGray();

                var converter = new conv(bitmap);
                var rows = converter.Convert();

                foreach (var row in rows)
                    Console.WriteLine(row);

                File.WriteAllLines("image.txt", rows.Select(r=> new string(r)));

                Console.SetCursorPosition(0, 0);

            }

        }


        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var newH = bitmap.Height / WID * m_W / bitmap.Width;
            if (bitmap.Width > m_W || bitmap.Height > newH)
                bitmap = new Bitmap(bitmap, new Size(m_W, (int)newH));
            return bitmap;
        }
    }
}
