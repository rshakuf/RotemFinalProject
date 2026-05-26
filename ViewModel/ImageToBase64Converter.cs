using System;
using System.IO;

namespace ViewModel
{
    public static class ImageToBase64Converter
    {
        public static string ImageFromResourceToBase64(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            try
            {
                var assembly = typeof(ImageToBase64Converter).Assembly;
                string resourcePath = $"ViewModel.mypictures.{fileName}";

                using Stream stream = assembly.GetManifestResourceStream(resourcePath);

                if (stream == null)
                    return null;

                using var ms = new MemoryStream();
                stream.CopyTo(ms);
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return null;
            }
        }
    }
}
