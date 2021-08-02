using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Calculator.Presentation.Models.Serialization
{
    public class ApiResponseContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.DeclaringType == typeof(CalculateApiResponse))
            {
                property.ShouldSerialize = instance =>
                    !property.PropertyName
                        .Equals(nameof(CalculateApiResponse.StatusCode), System.StringComparison.OrdinalIgnoreCase);
            }

            return property;
        }
    }
}
