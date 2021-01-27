using System;

namespace LifecycleBlazorApp.Store
{
    public interface IActionDispatcher
    {
        void Dispatcher(IAction action);
        void Subscribe(Action<IAction> ActionHandler);
        void UnSubscribe(Action<IAction> ActionHandler);
    }
}