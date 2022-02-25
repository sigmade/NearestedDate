using System;
using System.Collections.Generic;
using System.Linq;

namespace NearestedDate
{
    internal class Program
    {
        private static List<DateTime> ClsDate = new List<DateTime>();
        private static List<DateTime> ClsDateDesc = new List<DateTime>();

        static void Main(string[] args)
        {
            var init = new Initializer();

            //выгружаем отсортировааные даты в лист,
            //чтобы только один раз в бд обратиться
            ClsDate = init.Classifiers()
                .OrderBy(x => x.Date)
                .Select(x => x.Date)
                .ToList();

            ClsDateDesc = init.Classifiers()
                .OrderByDescending(x => x.Date)
                .Select(x => x.Date)
                .ToList();


            var outPut = from input in init.InputData()
                         select new OutputData
                         {
                             Id = input.Id,
                             Date = input.Date,
                             ClassifierDate = NearDate(input.Date)
                         };
            foreach (var i in outPut)
            {
                Console.WriteLine($"{i.Id} -- {i.Date} -- {i.ClassifierDate}");
            }

            Console.ReadKey();
        }

        public static DateTime NearDate(DateTime date)
        {
            var mindate = ClsDateDesc
                .Where(d => d.Date <= date)
                .First();

            var maxdate = ClsDate
                .Where(d => d.Date >= date)
                .First();

            if ((date - mindate) < (maxdate - date))
            {
                return mindate;
            }
            else
            {
                return maxdate;
            }
        }
    }
}
