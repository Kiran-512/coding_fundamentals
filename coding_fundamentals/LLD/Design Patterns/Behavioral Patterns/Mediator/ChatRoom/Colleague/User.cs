using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.MediatorInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Colleague
{
    public class User
    {
        private IChatRoomMediator _mediator;
        public string Name { get; private set; }
        public User(IChatRoomMediator mediator, string name)
        {
            _mediator = mediator;
            Name = name;
        }
        public void Send(string message)
        {
            Console.WriteLine($"{Name} sends: {message}");
            _mediator.SendMessage(message, this);
        }
        public void Receive(string message)
        {
            Console.WriteLine($"{Name} receives: {message}");
        }
    }
}
