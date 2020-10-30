using System;
using System.Reflection;

namespace TestSuite.Utils
{
    internal static class ReflectionUtils
    {
        public static FieldInfo GetPrivateAttribute(Type type, string name) =>
            type.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);

        public static PropertyInfo GetPublicProperty(Type type, string name) =>
            type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
    }
}