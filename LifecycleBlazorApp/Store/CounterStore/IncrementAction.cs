using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifecycleBlazorApp.Store.CounterStore
{
    public class IncrementAction : IAction
    {
        public const string INCREMENT = "INCREMENT";

        public string Name => INCREMENT;
    }
}
