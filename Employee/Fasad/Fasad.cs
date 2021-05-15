using System;

namespace Fasad
{
    public class Fasad
    {
        static void Main(string[] args)
        {
            RecordEditor recordEditor = new RecordEditor();
            Generator generator = new Generator();
            CLR clr = new CLR();

            EditorRecordFacade record = new EditorRecordFacade(recordEditor, generator, clr);

            Accountant accountant = new Accountant();
            accountant.CreateRecord(record);

            Console.Read();
        }
    }
    class RecordEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Написання звіту");
        }
        public void Save()
        {
            Console.WriteLine("Зберігання звіту");
        }
    }
    class Generator
    {
        public void Generate()
        {
            Console.WriteLine("Генерування звіту");
        }
    }
    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Виконання генерації");
        }
        public void Finish()
        {
            Console.WriteLine("Завершення роботи генерації");
        }
    }
    class EditorRecordFacade
    {
        RecordEditor recordEditor;
        Generator generator;
        CLR clr;
        public EditorRecordFacade(RecordEditor re, Generator generat, CLR clr)
        {
            this.recordEditor = re;
            this.generator = generat;
            this.clr = clr;
        }
        public void Start()
        {
            recordEditor.CreateCode();
            recordEditor.Save();
            generator.Generate();
            clr.Execute();
        }
        public void Stop()
        {
            clr.Finish();
        }
    }
    class Accountant
    {
        public void CreateRecord(EditorRecordFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
