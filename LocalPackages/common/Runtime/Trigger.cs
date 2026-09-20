using System;

namespace LocalPackages.Common
{
    public sealed class Trigger<TParam>
    {
        public event Action<TParam> OnCall;

        public void Call(TParam param)
        {
            OnCall?.Invoke(param);
        }
    }
}