using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sorc {
    public class Ownership {
        public static Ownership Parse(JToken jtok) {
            return new Ownership() {
                __type = StringToType.Map[(string)jtok["__type"]]
            };
        }

        private Ownership() { }

        public Type __type { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
