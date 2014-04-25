using System;
using System.Collections.Generic;
using System.Drawing;
using ZXing;
using ZXing.Common;


namespace BarDecode
{
    public class BarDecoder
    {
        public static Config CreateConfig(bool productsOnly = false, bool tryHarder = false, bool pureBarcode = false)
        {
            Config config = new Config(productsOnly, tryHarder, pureBarcode);
            config.Hints = BuildHints(config);
            return config;
        }

        public Result Decode(Bitmap image, Config config = null)
        {
            config = config ?? Config.Default;
            Result result;
            using (image)
            {
                LuminanceSource source;
                if (config.Crop == null)
                    source = new BitmapLuminanceSource(image);
                else
                {
                    int[] crop = config.Crop;
                    source = new BitmapLuminanceSource(image).crop(crop[0], crop[1], crop[2], crop[3]);
                }
                BinaryBitmap bitmap = new BinaryBitmap(new HybridBinarizer(source));
                result = new MultiFormatReader().decode(bitmap, config.Hints);
            }
            return result;
        }

        // Manually turn on all formats, even those not yet considered production quality.
        private static IDictionary<DecodeHintType, object> BuildHints(Config config)
        {
            var hints = new Dictionary<DecodeHintType, Object>();
            var vector = new List<BarcodeFormat>(8)
                    {
                       BarcodeFormat.UPC_A,
                       BarcodeFormat.UPC_E,
                       BarcodeFormat.EAN_13,
                       BarcodeFormat.EAN_8,
                       BarcodeFormat.RSS_14,
                       BarcodeFormat.RSS_EXPANDED
                    };
            if (!config.ProductsOnly)
            {
                vector.Add(BarcodeFormat.CODE_39);
                vector.Add(BarcodeFormat.CODE_93);
                vector.Add(BarcodeFormat.CODE_128);
                vector.Add(BarcodeFormat.ITF);
                vector.Add(BarcodeFormat.QR_CODE);
                vector.Add(BarcodeFormat.DATA_MATRIX);
                vector.Add(BarcodeFormat.AZTEC);
                vector.Add(BarcodeFormat.PDF_417);
                vector.Add(BarcodeFormat.CODABAR);
                vector.Add(BarcodeFormat.MAXICODE);
            }
            hints[DecodeHintType.POSSIBLE_FORMATS] = vector;
            if (config.TryHarder)
            {
                hints[DecodeHintType.TRY_HARDER] = true;
            }
            if (config.PureBarcode)
            {
                hints[DecodeHintType.PURE_BARCODE] = true;
            }
            return hints;
        }
    }
}
