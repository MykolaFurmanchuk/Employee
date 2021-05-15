using System;

namespace sequence
{
    public class Sequence
    {
        static void Main(string[] args)
        {
            Archive archive = new Archive();
            Reader reader = new Reader();
            reader.SeeRecords(archive);
            Console.Read();
        }
    }
    class Reader
    {
        public void SeeRecords(Archive archive)
        {
            IRecordIterator iterator = archive.CreateNumerator();
            while (iterator.HasNext())
            {
                Record record= iterator.Next();
                Console.WriteLine(record.Date);
            }
        }
    }
    interface IRecordIterator
    {
        bool HasNext();
        Record Next();
    }
    interface IRecordNumerable
    {
        IRecordIterator CreateNumerator();
        int Count { get; }
        Record this[int index] { get; }
    }
    class Record
    {
        public string Date { get; set; }
    }

    class Archive : IRecordNumerable
    {
        private Record[] records;
        public Archive()
        {
            records = new Record[]
            {
            new Record {Date="2021-04-12"},
            new Record {Date="2021-03-12"},
            new Record {Date="2021-02-12"},
            new Record {Date="2021-01-12"},
            new Record {Date="2021-05-12"}
            };
        }
        public int Count
        {
            get { return records.Length; }
        }

        public Record this[int index]
        {
            get { return records[index]; }
        }
        public IRecordIterator CreateNumerator()
        {
            return new RecordNumerator(this);
        }
    }
    class RecordNumerator : IRecordIterator
    {
        IRecordNumerable aggregate;
        int index = 0;
        public RecordNumerator(IRecordNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Record Next()
        {
            return aggregate[index++];
        }
    }
}
