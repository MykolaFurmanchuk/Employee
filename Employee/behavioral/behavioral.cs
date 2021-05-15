using System;

namespace behavioral
{
    public class behavioral
    {
        static void Main(string[] args)
        {
            ManagerMediator mediator = new ManagerMediator();
            Colleague accontant = new AccontantColleague(mediator);
            Colleague employee = new EmployeeColleague(mediator);
            mediator.Accountant = accontant;
            mediator.Employee = employee;
            accontant.Send("Поставлено нові терміни здачі роботи");
            employee.Send("Роботу виконано");
          
            Console.Read();
        }
    }
    abstract class Manager
    {
    public abstract void Send(string msg, Colleague colleague);
}
abstract class Colleague
{
        protected Manager mediator;
 
    public Colleague(Manager mediator)
    {
        this.mediator = mediator;
    }
 
    public virtual void Send(string message)
    {
        mediator.Send(message, this);
    }
    public abstract void Notify(string message);
}
class AccontantColleague : Colleague
{
    public AccontantColleague(Manager mediator)
        : base(mediator)
    { }
 
    public override void Notify(string message)
    {
        Console.WriteLine("Повідомлення бухгалтеру: " + message);
    }
}

class EmployeeColleague : Colleague
{
    public EmployeeColleague(Manager mediator)
        : base(mediator)
    { }
 
    public override void Notify(string message)
    {
        Console.WriteLine("Сообщение программисту: " + message);
    }
}
class ManagerMediator : Manager
    {
    public Colleague Accountant { get; set; }
    public Colleague Employee { get; set; }
     public override void Send(string msg, Colleague colleague)
    {
 
        if (Accountant == colleague)
                Employee.Notify(msg);

        else if (Employee == colleague)
                Accountant.Notify(msg);
    }
}
}
