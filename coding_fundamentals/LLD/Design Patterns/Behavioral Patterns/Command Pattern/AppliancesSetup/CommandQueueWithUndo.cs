using All.Design.Patterns.Behavioral_Patterns.Command_Pattern.Command_Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.Behavioral_Patterns.Command_Pattern.LightOnOff
{
    public class CommandQueueWithUndo
    {
        private readonly Queue<ICommand> _commands = new Queue<ICommand>();
        private readonly Stack<ICommand> _executedCommands = new Stack<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Enqueue(command);
        }

        public void ExecuteAll()
        {
            while (_commands.Count > 0)
            {
                var command = _commands.Dequeue();
                command.Execute();
                _executedCommands.Push(command);
            }
        }

        public void UndoLast()
        {
            if (_executedCommands.Count > 0)
            {
                var command = _executedCommands.Pop();
                command.Undo();
            }
        }
    }

}
