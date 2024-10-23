using System;

namespace StateMachine
{
    public class Transition
    {
        public IState From { get; private set; }
        public IState To { get; private set; }
        public Func<bool> Condition { get; private set; }

        public Transition(IState from, IState to, Func<bool> condition)
        {
            From = from;
            To = to;
            Condition = condition;
        }
    }
}