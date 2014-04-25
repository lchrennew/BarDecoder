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
            Bitmap image = new Bitmap(@"yy.jpg");
            var result = new BarDecoder().Decode(image, BarDecoder.CreateConfig(tryHarder:true));

            Console.WriteLine(result.Text);

            Console.Read();
        }
    }
}
