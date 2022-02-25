using System;
using System.Collections.Generic;

namespace NearestedDate
{
    internal class Initializer
    {
        public List<Classifier> Classifiers()
        {
            return new List<Classifier>
            {
                new () { Id = 1, Date = DateTime.Parse("01.01.2020") },
                new () { Id = 2, Date = DateTime.Parse("01.01.2021") },
                new () { Id = 3, Date = DateTime.Parse("01.01.2022") },
                new () { Id = 3, Date = DateTime.Parse("01.01.2023") }
            };
        }

        public List<InputData> InputData()
        {
            return new List<InputData>
            {
                new () { Id = 1, Date = DateTime.Parse("01.02.2022") },
                new () { Id = 2, Date = DateTime.Parse("01.02.2021") },
                new () { Id = 3, Date = DateTime.Parse("12.30.2020") }
            };
        }
    }

    public class Classifier
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }

    public class InputData
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
    }

    public class OutputData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime ClassifierDate { get; set; }
    }
}
