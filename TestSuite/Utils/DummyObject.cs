/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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

        public static DummyObject CreateDefault()
        {
            return new DummyObject(0);
        }
    }
}