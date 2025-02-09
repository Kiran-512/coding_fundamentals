using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.Colleague;
using All.Design.Patterns.Behavioral_Patterns.Mediator.ATC.ConcreteMediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Mediator.ChatRoomHost
{
    public class ChatRoomHost
    {
        public static void main()
        {
            var mediator = new ChatRoom();

            var user1 = new User(mediator, "Alice");
            var user2 = new User(mediator, "Bob");
            var user3 = new User(mediator, "Charlie");

            mediator.AddUser(user1);
            mediator.AddUser(user2);
            mediator.AddUser(user3);

            user1.Send("Hello everyone!");
            user2.Send("Hi Everyone!");
        }
    }
}

/*
 Here no users knows each other at all!
 */
