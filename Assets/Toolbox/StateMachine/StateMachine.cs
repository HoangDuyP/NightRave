namespace Pekame
{
    public class StateMachine
    {
        private State state;

        public State State
        {
            get => state;
            set
            {
                if (state == value) return;
                state?.End();
                state = value;
                state?.Start();
            }
        }

        public StateMachine(State initialState)
        {
            State = initialState;
        }

        public void Update() => State?.Loop();
    }
}