using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sorc {
    public class Block {
        public static Block Parse(JToken jtok) {
            return new Block() {
                __type = StringToType.Map[(string)jtok["__type"]],
                nodes = jtok["nodes"].Select(tok => Node.Parse(tok)).ToList(),
                resultType = ResultType.Parse(jtok["resultType"])
            };
        }

        private Block() { }

        public Type __type { get; set; }
        public List<Node> nodes { get; set; }
        public ResultType resultType { get; set; }

        public override string ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
