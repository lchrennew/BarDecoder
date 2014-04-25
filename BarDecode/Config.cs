using System.Collections.Generic;
using ZXing;

namespace BarDecode
{
    public sealed class Config
    {
        public IDictionary<DecodeHintType, object> Hints { get; set; }

        /// <summary>
        /// Use the TRY_HARDER hint, default is normal (mobile) mode
        /// </summary>
        public bool TryHarder { get; set; }

        /// <summary>
        /// Input image is a pure monochrome barcode image, not a photo
        /// </summary>
        public bool PureBarcode { get; set; }

        /// <summary>
        /// Only decode the UPC and EAN families of barcodes
        /// </summary>
        public bool ProductsOnly { get; set; }

        /// <summary>
        /// crop=left,top,width,height: Only examine cropped region of input image(s)
        /// </summary>
        public int[] Crop { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsOnly"></param>
        /// <param name="tryHarder"></param>
        /// <param name="pureBarcode"></param>
        public Config(bool productsOnly = false, bool tryHarder = false, bool pureBarcode = false)
        {
            ProductsOnly = productsOnly;
            TryHarder = tryHarder;
            PureBarcode = pureBarcode;
        }

        static readonly Config defaultConfig = new Config();
        public static Config Default { get { return defaultConfig; } }
    }
}
