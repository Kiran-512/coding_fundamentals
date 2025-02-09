using All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.CoR.Quize_Game.Abstract_Handler
{
    public interface IParticipant
    {
        IParticipant NextParticipent { get; set; }
        string Name { get; set; }
        int Score { get; set; }
        void DoAnswer(IQuestion question);
    }
}
