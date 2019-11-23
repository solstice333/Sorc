using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sorc {
    class MainClass {
        static MainClass() {
            FatalTraceListener.SetAsOnlyListener();
        }

        public static void Main(string[] args) {
            Args.Parse(args);

            foreach (string path in Args.vale_il_files) {
                using (var sr = File.OpenText(path)) {
                    JObject vil = 
                        (JObject)JToken.ReadFrom(new JsonTextReader(sr));
                }
            }
        }
    }
}
