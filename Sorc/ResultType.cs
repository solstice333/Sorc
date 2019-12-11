using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sorc {
    public class ResultType {
        public static ResultType Parse(JToken jtok) {
            return new ResultType() {
                __type = StringToType.Map[(string)jtok["__type"]],
                ownership = Ownership.Parse(jtok["ownership"]),
                kind = Kind.Parse(jtok["kind"])
            };
        }

        private ResultType() { }

        public Type __type { get; set; }
        public Ownership ownership { get; set; }
        public Kind kind { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
