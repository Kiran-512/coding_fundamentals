using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Handler;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Models
{
    public interface IQuestion
    {
        string Question1 { get; }
        IParticipant Owner { get; set; }
        bool CheckAnswer(string answer);
    }
}
