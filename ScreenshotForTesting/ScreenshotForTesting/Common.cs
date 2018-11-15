using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace ScreenshotForTesting
{
    public class Common
    {
        public static void SaveBitmap(Bitmap bitmap, string path)
        {
            var encoder = ImageCodecInfo.GetImageEncoders()
                            .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
            var encParams = new EncoderParameters(1);
            encParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
            bitmap.Save(path, encoder, encParams);
        }
    }
}
