using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ColorProcessing
{
    public class ColorProcessing
    {
        public Tuple<int, int> CountTemperatureIndex(int red, int green, int blue, int minValue, int maxValue)
        {
            List<int> values = new List<int>();
            for (int i = minValue; i < maxValue; i++)
            {
                values.Add(i);
            }

            var list = Split(values, values.Count / 4 + 1);

            if (blue > green && blue > red)
            {
                return new Tuple<int, int>(list.ElementAt(0).Min(), list.ElementAt(0).Max());
            }
            else if (green > red && green > blue)
            {
                return new Tuple<int, int>(list.ElementAt(1).Min(), list.ElementAt(1).Max());
            }
            else if (red > green && red > blue)
            {
                return new Tuple<int, int>(list.ElementAt(1).Min(), list.ElementAt(1).Max());
            }
            else
            {
                return new Tuple<int, int>(list.ElementAt(1).Min(), list.ElementAt(1).Max());
            }
        }

        private static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize = 30)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        }

        public static List<List<T>> Split<T>(List<T> collection, int size)
        {
            var chunks = new List<List<T>>();
            var chunkCount = collection.Count() / size;

            if (collection.Count % size > 0)
                chunkCount++;

            for (var i = 0; i < chunkCount; i++)
                chunks.Add(collection.Skip(i * size).Take(size).ToList());

            return chunks;
        }
    }
}