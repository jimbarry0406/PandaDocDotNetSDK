using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Reflection;

namespace PandaDocDotNetSDK
{

    internal static class JsonUtils
    {

        internal class ShouldSerializeContractResolver : DefaultContractResolver
        {

            public static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {

                // Get Property
                JsonProperty? property = null;
                try
                {
                    property = base.CreateProperty(member, memberSerialization);
                }
                catch
                {
                    property = null;
                }

                // Validate Property
                if (
                            (property != null)
                        &&  (property.PropertyType != null)
                        &&  (property.PropertyType != typeof(string))
                        &&  (property.PropertyType != typeof(String))
                        &&  typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
                )
                {

                    // Assign Function
                    property.ShouldSerialize =
                        instance =>
                        {

                            // Attempt Assignment, Best Efforts
                            IEnumerable? enumerable = null;
                            try
                            {
                                PropertyInfo? pi = instance.GetType().GetProperty(member.Name);
                                if (pi != null)
                                {

                                    // this value could be in a public field or public property
                                    switch (member.MemberType)
                                    {
                                        case MemberTypes.Property:
                                            enumerable = pi.GetValue(instance, null) as IEnumerable;
                                            break;
                                        case MemberTypes.Field:
                                            enumerable = pi.GetValue(instance) as IEnumerable;
                                            break;
                                    }

                                } // pi != null
                            }
                            catch
                            {
                                enumerable = null;
                            }

                            // if the list is null, defer the decision to NullValueHandling
                            return ((enumerable == null) || enumerable.GetEnumerator().MoveNext());

                        };

                } // Valid Property

                // Final Answer
                if (property == null)
                {
                    return new JsonProperty();
                }
                else
                {
                    return property;
                }

            } // CreateProperty

        } // ShouldSerializeContractResolver

    } // class JsonUtils

} // namespace PandaDocDotNetSDK
