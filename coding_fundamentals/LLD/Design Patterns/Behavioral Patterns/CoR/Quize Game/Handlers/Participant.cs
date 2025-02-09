using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Handler;
using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Handlers
{
    public class Participant : IParticipant
    {
        public IParticipant NextParticipent { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public Participant(IParticipant nextParticipent)
        {
            NextParticipent = nextParticipent;
            Score = 0;
        }
        public void DoAnswer(IQuestion question)
        {
            Console.WriteLine("Hi " + this.Name + ", Please answer for the question: " + question.Question1);
            string ans = Console.ReadLine();

            if (question.CheckAnswer(ans))
            {
                Console.WriteLine("Correct Answer");
                this.Score += 1;
            }
            else if (NextParticipent != question.Owner)
            {
                Console.WriteLine("Wrong Answer. Passing to next participant.");
                NextParticipent.DoAnswer(question);
            }
            else
            {
                Console.WriteLine("No one answered correctly.");
            }
        }
    }
}
