using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Colleague;
using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.MediatorInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.ConcreteMediator
{
    public class ChatRoom : IChatRoomMediator
    {
        List<User> _users = new List<User>();
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.Receive(message);
                }

            }
        }


    }
}
