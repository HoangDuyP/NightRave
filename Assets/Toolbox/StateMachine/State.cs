using System;

namespace Pekame
{
    public class State
    {
        private Action start, loop, end;

        public void Start() => start?.Invoke();
        public void Loop() => loop?.Invoke();
        public void End() => end?.Invoke();

        public State SetStart(Action action)
        {
            start = action;
            return this;
        }

        public State SetLoop(Action action)
        {
            loop = action;
            return this;
        }

        public State SetEnd(Action action)
        {
            end = action;
            return this;
        }
    }
}