using System;
using System.Collections.Generic;
using System.Linq;

namespace WizardFX
{
    public class Args
    {
        private readonly Dictionary<string, object> _args = new Dictionary<string, object>();

        public int Count
        {
            get { return _args.Count(); }
        }

        public object this[string key]
        {
            get
            {
                return _args[key];
            }
        }

        public void AddOrReplace(string key, object value)
        {
            if (_args.Keys.Contains(key))
                _args.Remove(key);

            _args.Add(key, value);
        }
    }
}