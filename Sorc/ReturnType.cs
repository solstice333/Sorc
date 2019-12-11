using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sorc {
    public class ReturnType {
        public static ReturnType Parse(JToken jtok) {
            return new ReturnType() {
                __type = StringToType.Map[(string)jtok["__type"]],
                ownership = Ownership.Parse(jtok["ownership"]),
                kind = Kind.Parse(jtok["kind"])
            };
        }

        private ReturnType() { }

        public Type __type { get; set; }
        public Ownership ownership { get; set; }
        public Kind kind { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
