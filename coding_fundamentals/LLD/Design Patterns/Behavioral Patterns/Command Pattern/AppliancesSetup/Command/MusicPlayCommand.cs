using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Command_Interface;
using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.LightOnOff.Receiver;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.LightOnOff.Command
{
    public class MusicPlayCommand : ICommand
    {
        private readonly MusicSystem _musicSystem;
        public MusicPlayCommand(MusicSystem musicSystem) => _musicSystem = musicSystem;

        public void Execute() => _musicSystem.Play();
        public void Undo() => _musicSystem.Stop();
    }
}
