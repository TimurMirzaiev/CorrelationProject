using Correlation.Library;
using System;
using System.Collections.Generic;

namespace Correlation.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Statistic statistic = new Statistic();

            var dependedSample = new Sample()
            {
                Values = new List<double>()
                {
                    45, 65, 68, 65, 45, 65, 55, 65, 68, 68, 68, 65
                }
            };

            var independedSample = new Sample()
            {
                Values = new List<double>()
                {
                    34, 55, 68, 75, 42, 65, 52, 35, 58, 58, 75, 68
                }
            };


            var first = new Sample()
            {
                Values =
                {
                    86, 78, 642, 192, 571, 485, 553, 535, 328, 795, 830, 692
                }
            };

            var second = new Sample()
            {
                Values =
                {
                    187, 187, 653, 336, 336, 336, 672, 550, 404, 821, 578, 93
                }
            };

            var third = new Sample()
            {
                Values =
                {
                    102.9, 142, 353.1, 253.3, 169.9, 234.4, 277.9, 175.8
                }
            };

            var fourth = new Sample()
            {
                Values =
                {
                    424.9, 353.1, 310.2, 422, 454.2, 390.6, 372.4
                }
            };
            //statistic.MathematicExpectationsDepended(first, second);

            statistic.IsExistBias(first, second);
            //statistic.MathematicExpectationsIndepended(third, fourth);
            //statistic.MathematicExpectations(dependedSample, independedSample);
        }
    }
}
