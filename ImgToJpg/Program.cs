using System;
using System.IO;
using System.Drawing;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;

namespace ImngToJpg
{
    internal class Program
    {
        static void Main(string[] args)
        {

            foreach (string filePath in args)
            {
                using (FileStream in_fs = new FileStream(filePath, FileMode.Open))
                {
                    string newFilePath = Path.ChangeExtension(filePath, "jpg");
                    using (FileStream out_fs = new FileStream(newFilePath, FileMode.Create))
                    {
                        using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                        {
                            imageFactory.Load(in_fs)
                                        .Save(out_fs);
                        }
                    }
                }
            }
        }
    }
}





