using System;
using System.Collections.Generic;
using System.Linq;
using MarsAnalyzer.Data;
using MarsAnalyzer.Data.Model;

namespace MarsAnalyzer.Services.DataServices
{
    public class HeatMapHelper
    {
        public void InsertArrayOfPoints(PixelCondition[,] points)
        {
            using (var ctx = new NasaContext())
            {
                foreach (var point in points)
                {
                    ctx.MapPoints.Add(point);
                }

                ctx.SaveChanges();
            }
        }

        public IEnumerable<PixelCondition> GetAllPoints(int startPointX, int startPointY)
        {
            int length = 256;
            using (var ctx = new NasaContext())
            {
                return ctx.MapPoints.Where(point =>
                    point.X >= startPointX && point.X < startPointX + 256 && point.Y >= startPointY &&
                    point.Y <= startPointY + 256).ToList();
            }
        }
        
    }
}