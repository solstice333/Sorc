using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sorc {
    public class Node {
        public static Node Parse(JToken jtok) {
            return new Node() {
                __type = StringToType.Map[(string)jtok["__type"]],
                registerId = (string)jtok["registerId"],
                value = (int)jtok["value"]
            };
        }

        private Node() { }

        public Type __type { get; set; }
        public string registerId { get; set; }
        public int value { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
