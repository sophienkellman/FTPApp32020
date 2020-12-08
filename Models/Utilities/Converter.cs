using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace FTPApp3.Models.Utilities
{
    class Converter
    {

        /// <summary>
        /// Converts a Base64 encoded string to an Image
        /// </summary>
        /// <param name="base64String">Base64 encoded Image string</param>
        /// <returns>Decoded Image</returns>
        public static Image Base64ToImage(string base64String)
        {
            try
            {
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(base64String.Trim());
                var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);
                return image;
            }
            catch (Exception e)
            {

            }

            //Something went wrong in the Base64 string
            return null;
        }

    }
}
