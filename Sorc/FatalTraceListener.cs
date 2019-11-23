using System;
using System.Diagnostics;

namespace Sorc {
    class FatalTraceListener : TraceListener {
        public static void SetAsOnlyListener() {
            Debug.Listeners.Clear();
            Debug.Listeners.Add(new FatalTraceListener());
        }

        public override void Write(string message) {
            Console.WriteLine(message);
            Console.Write(new StackTrace(true));
            Environment.Exit(1);
        }

        public override void WriteLine(string message) {
            Console.WriteLine(message);
            Console.WriteLine(new StackTrace(true));
            Environment.Exit(1);
        }
    }
}
