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
                using (StreamReader sr = File.OpenText(path)) {
                    JObject vil = 
                        (JObject)JToken.ReadFrom(new JsonTextReader(sr));

                    Trace.Assert((string)vil["__type"] == "Function");

                    Prototype proto = Prototype.Parse(vil["prototype"]);
                    Block block = Block.Parse(vil["block"]);

                    Trace.Assert(proto.ToString() == "{\"__type\":\"Prototype\",\"globalName\":\"main\",\"args\":[],\"returnType\":{\"__type\":\"Reference\",\"ownership\":{\"__type\":\"Share\"},\"kind\":{\"__type\":\"Int\"}}}");
                    Trace.Assert(block.ToString() == "{\"__type\":\"Block\",\"nodes\":[{\"__type\":\"ConstantI64\",\"registerId\":\"0\",\"value\":42}],\"resultType\":{\"__type\":\"Reference\",\"ownership\":{\"__type\":\"Share\"},\"kind\":{\"__type\":\"Int\"}}}");

                    // TODO: try disassembling sample code with monodis
                    // TODO: try using cecil to write to cil
                }
            }
        }
    }
}
