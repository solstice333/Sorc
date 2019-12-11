using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Sorc {
    public class Prototype {
        public static Prototype Parse(JToken jtok) {
            return new Prototype() {
                __type = StringToType.Map[(string)jtok["__type"]],
                globalName = (string)jtok["globalName"],
                args = jtok["args"].Select(o => (object)o).ToArray(),
                returnType = ReturnType.Parse(jtok["returnType"])
            };
        }

        private Prototype() { }

        public Type __type { get; set; }
        public string globalName { get; set; }
        public object[] args { get; set; }
        public ReturnType returnType { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
