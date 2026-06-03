using System;
using System.IO;

namespace ViewModel
{
    public static class ImageToBase64Converter
    {
        /// <summary>
        /// Set once at API startup to the runtime "mypictures" folder on disk.
        /// When set, newly-uploaded photos are found here before falling back to
        /// the embedded resources that contain the original pre-loaded pictures.
        /// </summary>
        public static string PicturesFolder { get; set; }

        public static string ImageFromResourceToBase64(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            try
            {
                // 1. Try the on-disk pictures folder (used for user-uploaded photos)
                if (!string.IsNullOrEmpty(PicturesFolder))
                {
                    string diskPath = Path.Combine(PicturesFolder, fileName);
                    if (File.Exists(diskPath))
                    {
                        byte[] diskBytes = File.ReadAllBytes(diskPath);
                        return Convert.ToBase64String(diskBytes);
                    }
                }

                // 2. Fall back to embedded resources (original pre-loaded pictures)
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
