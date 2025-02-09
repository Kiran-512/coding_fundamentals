using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Handler;
using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Models
{
    public class Question : IQuestion
    {
        public string Question1 { get; private set; }
        public string Answer { get; private set; }
        public IParticipant Owner { get; set; }
        public Question(string question, string answer)
        {
            Question1 = question;
            Answer = answer;
        }
        public bool CheckAnswer(string answer)
        {
            return answer.Equals(Answer, StringComparison.OrdinalIgnoreCase);
        }
    }
}
