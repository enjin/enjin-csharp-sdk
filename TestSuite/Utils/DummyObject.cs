using Newtonsoft.Json;

namespace TestSuite.Utils
{
    public class DummyObject
    {
        public int Integer { get; }

        [JsonConstructor]
        public DummyObject(int integer)
        {
            Integer = integer;
        }

        public override bool Equals(object obj)
        {
            return (obj as DummyObject)?.Integer == Integer;
        }

        public override int GetHashCode()
        {
            return Integer;
        }
    }
}