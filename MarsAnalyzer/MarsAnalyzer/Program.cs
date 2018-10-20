using System;
using System.Drawing;
using MarsAnalyzer.Data.Model;
using MarsAnalyzer.Services.DataServices;

namespace MarsAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            //width: 2048
            //height: 1024
            string basePth = @"E:\mars_map\resize\";
            Bitmap img = new Bitmap(basePth + "rsz_mola.png");
            PixelCondition[,] array = new PixelCondition[img.Width, img.Height];

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    array[i, j] = new PixelCondition()
                    {
                        X = i,
                        Y = j,
                        HeightCoef = 765 / 100 * (Convert.ToInt32(pixel.R) + Convert.ToInt32(pixel.G) + Convert.ToInt32(pixel.B)), 
                    };
                }
            }
            img = new Bitmap(basePth + "rsz_temperature.png");
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    array[i, j].TemperatureCoef =
                        765 / 100 * (Convert.ToInt32(pixel.R) + Convert.ToInt32(pixel.G) + Convert.ToInt32(pixel.B));
                }
            }
            
            img = new Bitmap(basePth + "rsz_gravity.png");
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    array[i, j].GravityCoef =
                        765 / 100 * (Convert.ToInt32(pixel.R) + Convert.ToInt32(pixel.G) + Convert.ToInt32(pixel.B));
                }
            }
            
            DatabaseAccessLayerHelper.HeatMapHelper.InsertArrayOfPoints(array);
        }
    }
}