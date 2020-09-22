using System;
using System.Reflection;

namespace TestSuite.Utils
{
    internal static class ReflectionUtils
    {
        public static FieldInfo GetPrivateAttribute(Type type, string name) =>
            type.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
    }
}