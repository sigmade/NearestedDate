using System;
using System.Linq;

namespace NearestedDate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var init = new Initializer();

            //выгружаем отсортировааные даты в лист,
            //чтобы только один раз в бд обратиться
            var clsDate = init.Classifiers()
                .OrderByDescending(x => x.Date)
                .Select(x => x.Date)
                .ToList();

            var outPut = from input in init.InputData()
                         select new OutputData
                         {
                             Id = input.Id,
                             Date = input.Date,
                             ClassifierDate = clsDate // Проходимся по заранее выгруженному справочнику
                                                      // отсекаем что меньше  
                                .Where(d => d.Date <= input.Date) 
                                .First() // забираем первый он и будет ближайший
                         };

            foreach (var i in outPut)
            {
                Console.WriteLine($"{i.Id} -- {i.Date} -- {i.ClassifierDate}");
            }

            Console.ReadKey();
        }
    }
}
