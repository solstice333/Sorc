using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sorc {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Type {
        Prototype, 
        Reference, 
        Share, 
        Int, 
        Block, 
        ConstantI64
    }

    public static class StringToType {
        private static Dictionary<string, Type> _map =
            new Dictionary<string, Type> {
                { "Prototype", Type.Prototype },
                { "Reference", Type.Reference },
                { "Share", Type.Share },
                { "Int", Type.Int },
                { "Block", Type.Block },
                { "ConstantI64", Type.ConstantI64 },
            };

        public static readonly Dictionary<string, Type> Map = _map;
    }
}
