using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sorc {
    public class Kind {
        public static Kind Parse(JToken jtok) {
            return new Kind() {
                __type = StringToType.Map[(string)jtok["__type"]]
            };
        }

        private Kind() { }

        public Type __type { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
