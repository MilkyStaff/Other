using System;
using System.Collections.Generic;

namespace StateMachine
{
    public class StateMachine
    {
        IState current;
        List<Transition> transitions;

        public StateMachine(IState startState, List<Transition> allTransitions)
        {
            current = startState;
            transitions = allTransitions;
        }

        public void Update()
        {
            List<Transition> availableTransitions = transitions.FindAll(x => x.From.Equals(current) && x.Condition());

            if (availableTransitions.Count != 0)
            {
                if (availableTransitions.Count > 1)
                    Console.WriteLine("More than one state Transitions available");

                SetState(availableTransitions[0].To);
            }

            if (current is IUpdatableState updateState)
                updateState.Update();
        }

        private void SetState(IState nextState)
        {
            if (current is IExitableState exitState)
                exitState.Exit();

            current = nextState;

            if (current is IEnterableState enterState)
                enterState.Enter();
        }
    }
}