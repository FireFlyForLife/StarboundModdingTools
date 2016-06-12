using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarboundModTools
{
    public static class SVars
    {
        //TODO: Add locks for thread safety
        static System.Collections.Generic.Dictionary<String, Object> vars = new Dictionary<string, object>();
        
        public static void Register(String key, Object value) {
            vars.Add(key, value);
        }

        public static void Change(String key, Object value) {
            Object o;
            if (vars.TryGetValue(key, out o) && o.GetType().Equals(value.GetType())) {
                vars.Remove(key);
                vars.Add(key, value);
            } else
                Console.WriteLine("error: stored value has type '" + o.GetType().Name + "' while new value has type '" + value.GetType().Name + "'.");
        }

        public static void Add(String key, Object value) {
            Object o;
            if (vars.TryGetValue(key, out o))
                Change(key, value);
            else
                Register(key, value);
        }

        public static T getValue<T> (String key) {
            Object obj;
            if (vars.TryGetValue(key, out obj) && obj is T)
                return (T)obj;
            else
                return default(T);
        }

        public static Type getType(String key) {
            Object value;
            if (vars.TryGetValue(key, out value)) {
                return value.GetType();
            } else
                return null;
        }
    }
}
