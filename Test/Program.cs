using BarDecode;
using System;
using System.Drawing;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            BarDecode.BarDecoder decoder = new BarDecode.BarDecoder();
            Bitmap image = new Bitmap(@"qr.png");
            var result = new BarDecoder().Decode(image);

            Console.WriteLine(result.Text);

            Console.Read();
        }
    }
}
