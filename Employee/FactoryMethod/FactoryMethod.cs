using System;

namespace FactoryMethod
{
    public class FactoryMethod
    {
        static void Main(string[] args)
        {
            Accauntant accauntant = new QuarterlyReportAccauntant("Бухгалтер");
            Report house2 = accauntant.Create();

            accauntant = new AnnualReportAccauntant("Головний бухгалтер");
            Report house = accauntant.Create();

            Console.ReadLine();
        }
    }
    abstract class Accauntant
    {
        public string Name { get; set; }
        public Accauntant(string n)
        {
            Name = n;
        }

        abstract public Report Create();
    }
    class QuarterlyReportAccauntant : Accauntant
    {
        public QuarterlyReportAccauntant(string n) : base(n)
        { }

        public override Report Create()
        {
            return new QuarterlyReport();
        }
    }
    class AnnualReportAccauntant : Accauntant
    {
        public AnnualReportAccauntant(string n) : base(n)
        { }

        public override Report Create()
        {
            return new AnnualReport();
        }
    }

    abstract class Report
    { }

    class QuarterlyReport : Report
    {
        public QuarterlyReport()
        {
            Console.WriteLine("Квартальний звіт зроблено");
        }
    }
    class AnnualReport : Report
    {
        public AnnualReport()
        {
            Console.WriteLine("Річний звіт зроблено");
        }
    }
}