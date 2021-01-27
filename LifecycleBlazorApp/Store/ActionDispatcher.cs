using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifecycleBlazorApp.Store
{
    public class ActionDispatcher : IActionDispatcher
    {
        private Action<IAction> registeredActionHandler;

        public void Subscribe(Action<IAction> ActionHandler)
        {
            registeredActionHandler += ActionHandler;
        }

        public void UnSubscribe(Action<IAction> ActionHandler)
        {
            registeredActionHandler -= ActionHandler;
        }

        public void Dispatcher(IAction action)
        {
            registeredActionHandler?.Invoke(action);
        }

    }
}
