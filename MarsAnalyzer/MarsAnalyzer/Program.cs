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
            string basePth = @"E:\mars_map\";
            Bitmap img = new Bitmap(basePth + "MOLA.png");
            PixelCondition[,] array = new PixelCondition[img.Width, img.Height];

            ColorProcessing.ColorProcessing processor = new ColorProcessing.ColorProcessing();


            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    var values = processor.CountTemperatureIndex(pixel.R, pixel.G, pixel.B, -8, 8);
                    array[i, j] = new PixelCondition()
                    {
                        X = i,
                        Y = j,
                        HeightMax = values.Item1,
                        HeightMin = values.Item2
                    };
                }
            }
            
            img = new Bitmap(basePth + "NIGHT_TEMPERATURE.png");
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);

                    var values = processor.CountTemperatureIndex(pixel.R, pixel.G, pixel.B, -153, 68);
                    array[i, j].TemperatureMax = values.Item1;
                    array[i, j].TemperatureMin = values.Item2;
                }
            }
            
            img = new Bitmap(basePth + "PRESSURE.png");
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    var values = processor.CountTemperatureIndex(pixel.R, pixel.G, pixel.B, 30, 1155);
                    array[i, j].PressureMax = values.Item1;
                    array[i, j].PressureMin = values.Item2;
                }
            }
            
            DatabaseAccessLayerHelper.HeatMapHelper.InsertArrayOfPoints(array);
        }
    }
}