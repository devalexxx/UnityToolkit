using System;
using System.Collections.Generic;

namespace UnityToolkit
{
    public class State<T>
    {
        public event Action<T, T> onChange;

        private T _state;

        public State(T p_init)
        {
            _state = p_init;
        }

        public void Set(T p_state)
        {
            if (!EqualityComparer<T>.Default.Equals(_state, p_state))
            {
                var t_prevState = _state;
                _state = p_state;
                onChange?.Invoke(t_prevState, _state);
            }
        }

        public static implicit operator T (State<T> p_state)
        {
            return p_state._state;
        }
    }
}
