using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfApp_bDs;
using static System.Math;
using static System.Convert;


namespace wpfApp_bDs.Logic
{
    internal class Calculate
    {
        public static double Profit(double summary, double period, double deposits, double percent)
        {
            var Month = Months(period);
            var AllSummary = Summary(summary, period, deposits);
            var Percent = Month / 12 * percent;

            return Round(AllSummary * Percent);
        }

        public static double Summary(double summary, double period, double deposits)
        {
            return Months(period) * deposits + summary;
        }

        public static double Months(double period)
        {
            return period / 30;
        }
    }
}
