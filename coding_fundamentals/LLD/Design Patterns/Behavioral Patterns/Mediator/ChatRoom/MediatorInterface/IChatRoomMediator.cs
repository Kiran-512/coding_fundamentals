using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Colleague;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.MediatorInterface
{
    public interface IChatRoomMediator
    {
        void SendMessage(string message, User user);
        void AddUser(User user);
    }
}
