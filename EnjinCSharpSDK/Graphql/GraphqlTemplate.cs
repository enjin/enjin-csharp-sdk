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

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using static Enjin.SDK.Utils.TextFormatting;

[assembly: InternalsVisibleTo("TestSuite")]

namespace Enjin.SDK.Graphql
{
    /// <summary>
    /// Represents the types of templates.
    /// </summary>
    public enum TemplateType
    {
        FRAGMENT,
        MUTATION,
        QUERY
    }

    /// <summary>
    /// Class for compiling and caching a GraphQL template.
    /// </summary>
    /// <seealso cref="GraphqlQueryRegistry"/>
    public class GraphqlTemplate
    {
        internal const string NAMESPACE_KEY = "#namespace";
        internal const string IMPORT_KEY = "#import";
        internal const string ARG_KEY = "#arg";

        /// <summary>
        /// Represents the namespace of the template.
        /// </summary>
        /// <value>The namespace.</value>
        public string NameSpace { get; }

        /// <summary>
        /// Represents the name of the template.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        /// Represents the type of the template.
        /// </summary>
        /// <value>The template type.</value>
        public TemplateType TemplateType { get; }

        /// <summary>
        /// Represents the body of the raw template. Lacks the namespace, imports, and parameters.
        /// </summary>
        /// <value>The body contents.</value>
        public string Contents { get; }

        /// <summary>
        /// Represents the compiled contents of the template. Replaces fragment references in contents with the fragment
        /// bodies.
        /// </summary>
        /// <value>The compiled body contents.</value>
        public string? CompiledContents { get; private set; }

        /// <summary>
        /// Represents the parameters of this template.
        /// </summary>
        /// <value>The list of parameters.</value>
        public List<string?> Parameters { get; } = new List<string?>();

        /// <summary>
        /// Represents the fragments that this template references.
        /// </summary>
        /// <value>The list of fragments.</value>
        public List<string> ReferencedFragments { get; } = new List<string>();

        private readonly Dictionary<string, GraphqlTemplate> _fragments;

        /// <summary>
        /// Sole constructor. Parses and compiles the passed contents.
        /// </summary>
        /// <param name="name">The namespace.</param>
        /// <param name="templateType">The template type.</param>
        /// <param name="contents">The raw line data.</param>
        /// <param name="fragments">The template fragments.</param>
        public GraphqlTemplate(string name, TemplateType templateType, string[] contents,
                               Dictionary<string, GraphqlTemplate> fragments)
        {
            var parts = name.Split('.');
            NameSpace = name;
            Name = parts[parts.Length - 1];
            TemplateType = templateType;
            Contents = ParseContents(contents);
            _fragments = fragments;
        }

        private string ParseContents(IEnumerable<string> contents)
        {
            var builder = new StringBuilder();

            foreach (var line in contents)
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith(ARG_KEY))
                {
                    Parameters.Add(ProcessArg(trimmed));
                }
                else if (trimmed.StartsWith(IMPORT_KEY))
                {
                    ReferencedFragments.Add(ProcessImport(trimmed));
                }
                else if (!string.IsNullOrWhiteSpace(trimmed) && !trimmed.StartsWith("#"))
                {
                    builder.Append(line).AppendLine();
                }
            }

            return builder.ToString();
        }

        internal void Compile()
        {
            if (TemplateType == TemplateType.FRAGMENT)
                return;

            var parameters = new List<string?>(Parameters);
            var processedFragments = new List<string>();
            var fragmentQueue = new Stack<GraphqlTemplate>();
            var builder = new StringBuilder(Contents);

            foreach (var fragment in ReferencedFragments)
            {
                fragmentQueue.Push(_fragments[fragment]);
            }

            while (fragmentQueue.Count > 0)
            {
                var template = fragmentQueue.Pop();

                if (processedFragments.Contains(template.NameSpace))
                    continue;

                foreach (var fragment in template.ReferencedFragments)
                {
                    fragmentQueue.Push(_fragments[fragment]);
                }

                foreach (var parameter in template.Parameters.Where(parameter => !parameters.Contains(parameter)))
                {
                    parameters.Add(parameter);
                }

                builder.Append(" ").Append(template.Contents);
                processedFragments.Add(template.NameSpace);
            }

            var replaceTerm = TemplateType.ToString().ToLower();
            var newTermBuilder = new StringBuilder($"{replaceTerm} {Name}");

            if (parameters.Count > 0)
            {
                newTermBuilder.Append("(")
                              .Append(string.Join(CommaSpaceDelimiter, parameters))
                              .Append(")");
            }

            CompiledContents = builder.ToString().Replace(replaceTerm, newTermBuilder.ToString());
        }

        internal static string? ReadNamespace(IEnumerable<string> contents)
        {
            return (from line in contents
                    where line.StartsWith(NAMESPACE_KEY)
                    select line.Split(' ')[1])
                .FirstOrDefault();
        }

        private static string? ProcessArg(string line)
        {
            var parts = line.Split(' ');

            return parts.Length switch
            {
                3 => $"${parts[1]}: {parts[2]}",
                4 => $"${parts[1]}: {parts[2]} = {parts[3]}",
                _ => null
            };
        }

        private static string ProcessImport(string line)
        {
            return line.Split(' ')[1];
        }
    }
}