using System;
using System.Collections;

namespace Sorc {
    public static class EnumerableExt {
        public static string ToString<T>(this IEnumerable seq) {
            string s = "";
            bool first = true;

            Action<T> consume_item = item => {
                if (first) {
                    s += item.ToString();
                    first = false;
                }
                else
                    s += $", {item.ToString()}";
            };

            s += "[";
            foreach (T item in seq) 
                consume_item(item);
            s += "]";

            return s;
        }
    }
}
