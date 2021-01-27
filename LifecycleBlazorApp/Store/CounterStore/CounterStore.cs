using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifecycleBlazorApp.Store.CounterStore
{
    public class CounterState
    {
        public int Count { get;  }
        public CounterState(int count)
        {
            Count = count;
        }
    }
    public class CounterStore
    {

        private CounterState _state;
        public IActionDispatcher ActionDispatcher { get; }

        public CounterStore(IActionDispatcher actionDispatcher)
        {
            _state = new CounterState(0);
            this.ActionDispatcher = actionDispatcher;
            this.ActionDispatcher.Subscribe(HandleActions);
        }
        public CounterState GetState()
        {
            return _state;
        }

        public void HandleActions(IAction action)
        {
            switch (action.Name)
            {
                case IncrementAction.INCREMENT:
                    IncrementCount();
                    break;
                case DecrementAction.DECREMENT:
                    DecrementCount();
                    break;
            }
        }

        public void IncrementCount()
        {
            var count = this._state.Count;
            count++;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }

        public void DecrementCount()
        {
            var count = this._state.Count;
            count--;
            this._state = new CounterState(count);
            BroadcastStateChange();
        }


        private Action _listener;

       

        public void AddStateChangeListener(Action listener)
        {
            _listener += listener;
        }

        public void RemoveStateChangeListener(Action listener)
        {
            _listener -= listener;
        }
        private void BroadcastStateChange()
        {
            _listener.Invoke();
        }
    }
}
