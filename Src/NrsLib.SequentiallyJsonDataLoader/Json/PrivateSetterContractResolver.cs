using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NrsLib.SequentiallyJsonDataLoader.Json {
    public class PrivateSetterContractResolver : DefaultContractResolver {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
            var jProperty = base.CreateProperty(member, memberSerialization);
            if (jProperty.Writable) {
                return jProperty;
            }

            var prop = member as PropertyInfo;

            jProperty.Writable = prop?.GetSetMethod(true) != null;

            return jProperty;
        }
    }
}
