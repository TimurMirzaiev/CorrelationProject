using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Correlation.Library;

namespace Correlation.Library
{
    public class Statistic
    {
        public Statistic()
        {

        }

        public void IsExistBias(Sample x, Sample y)
        {
            var z = Substract(x, y);
            
            var s = z.TransformTo(v => v > 0 ? 1 : 0);
            z.RemoveZeroes();

            var zAbs = z.Clone();
            zAbs = zAbs.TransformTo(v => Math.Abs(v));

            //ranks

            var zSorted = zAbs.Clone();
            zSorted.Values.Sort();
            var r = zAbs.GetRankSample();



            var sr = s.Values.Zip(r.Values, (s, r) => s * r);


            foreach (var item in zAbs.Values)
                Console.WriteLine(item);
        }

        public void MathematicExpectationsIndepended(Sample x, Sample y)
        {
            var xAverage = x.Values.Average();
            var yAverage = y.Values.Average();
            var xCount = x.Count;
            var yCount = y.Count;

            var Sx = CalculateS(x, xAverage, 2, 2);
            var Sy = CalculateS(y, yAverage, 2, 2);
            var F = Sx / Sy;

            var S2 = ((xCount - 1) * Sx + (yCount - 1) * Sy) / (xCount + yCount - 2);
            var t = (xAverage - yAverage) / (Math.Sqrt((S2 / xCount) + (S2 / yCount)));

            //replace
            var quantilF = 4.21;
            var quantilT = 2.16;

            #region Conclusion

            if (F <= quantilF)
            {
                Console.WriteLine("Дисперсии равные");
            }
            else
            {
                Console.WriteLine("Дисперсии не равные");
            }

            if(Math.Abs(t) > quantilT)
            {
                Console.WriteLine("Средние совокупностей отличаются");
            }
            else
            {
                Console.WriteLine("Средние совокупностей не отличаются");
            }

            #endregion
        }

        public void MathematicExpectationsDepended(Sample x, Sample y)
        {
            var count = x.Count;
            var z = Substract(x, y);
            var averageZ = z.Values.Average();

            var Sz = CalculateS(z, z.Values.Average(), 2, 1);
            var Sx = CalculateS(x, x.Values.Average(), 2, 2);
            var Sy = CalculateS(y, y.Values.Average(), 2, 2);

            //replace
            var quantilT = 2.20;
            var quantilF = 2.82;

            var averageX = x.Values.Average();
            var averageY = y.Values.Average();

            Console.WriteLine(Sz);
            Console.WriteLine(Sx);
            Console.WriteLine(Sy);
        }


        private double CalculateS(Sample z, double averageZ, int pow, int totalPow)
        {
            var sample = new Sample();
            foreach (var item in z.Values)
            {
                sample.Values.Add(Math.Pow(item - averageZ, pow));
            }
            var res = Math.Sqrt(sample.Values.Sum() / (sample.Count - 1));
            res = Math.Pow(res, totalPow);

            return res;
        }

        private Sample Substract(Sample dependedSample, Sample independedSample)
        {
            var res = new Sample();

            for (int i = 0; i < dependedSample.Values.Count; i++)
            {
                res.Values.Add(dependedSample.Values[i] - independedSample.Values[i]);
            }

            return res;
        }
    }
}
