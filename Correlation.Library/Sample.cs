using System;
using System.Collections.Generic;
using System.Linq;

namespace Correlation.Library
{
    public class Sample
    {
        public List<double> Values = new List<double>();

        public int Count
        {
            get { return Values.Count; }
        }

        public Sample Clone()
        {
            var res = new Sample()
            {
                Values = Values.ToList()
            };

            return res;
        }
        public void RemoveZeroes()
        {
            Values.RemoveAll(v => v == 0);
        }

        public Sample TransformTo(Func<double, double> func)
        {
            var res = new Sample();
            for (int i = 0; i < Values.Count; i++)
            {
                res.Values.Add(func.Invoke(Values[i]));
            }

            return res;
        }

        public Sample GetRankSample()
        {
            var res = this.Clone();
            res.Values.Sort();
            var resCount = res.Values.GroupBy(v => v).Select(v => new { Value = v, Count = v.Count() });

            var numbersRange = Enumerable.Range(1, Values.Count);

            for (int i = 0; i < Values.Count; i++)
            {

            }

            return res;
        }
    }
}
