using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Handler;
using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Models;
using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Handlers;
using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game
{
    public class QuizHost
    {
        private List<IQuestion> _questions;
        private List<IParticipant> _participents;

        public QuizHost(List<IQuestion> questions, List<IParticipant> participents)
        {
            _questions = questions;
            _participents = participents;
        }

        public void StartEvent()
        {
            Console.WriteLine("Start of quiz. Welcome All.\n");

            IParticipant currentParticipant = _participents.First();

            foreach (var q in _questions)
            {
                q.Owner = currentParticipant;
                currentParticipant.DoAnswer(q);
                currentParticipant = currentParticipant.NextParticipent;
            }

            Console.WriteLine("\nEnd of quiz. Scorecard:");
            foreach (var p in _participents)
            {
                Console.WriteLine(p.Name + " : " + p.Score);
            }

            Console.WriteLine("\nThanks for participating.");
        }

    }
    class Program
    {
        static void Main1(string[] args)
        {
            IParticipant p3 = new Participant(null) { Name = "Raja" };
            IParticipant p2 = new Participant(p3) { Name = "Sree" };
            IParticipant p1 = new Participant(p2) { Name = "Sumesh" };
            p3.NextParticipent = p1;

            List<IParticipant> participents = new List<IParticipant>() { p1, p2, p3 };

            IQuestion q1 = new Question("Is CPU a part of computer?", "Yes");
            IQuestion q2 = new Question("Is IAS a computer course?", "No");
            IQuestion q3 = new Question("Is computer an electronic device?", "Yes");

            List<IQuestion> questions = new List<IQuestion>() { q1, q2, q3 };

            QuizHost myQuiz = new QuizHost(questions, participents);
            myQuiz.StartEvent();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
