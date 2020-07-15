using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Enjin.SDK.Utils.TextFormatting;

namespace Enjin.SDK.Graphql
{
    public enum TemplateType
    {
        Fragment,
        Mutation,
        Query
    }
    public class GraphqlTemplate
    {
        private const string FragmentToken = "...";
        private const string ParameterToken = "$";
        
        public string Name { get; }
        public TemplateType TemplateType { get; }
        public string Contents { get; }
        public string CompiledContents { get; private set; }
        public List<string> Parameters { get; } = new List<string>();
        public List<string> ReferencedFragments { get; } = new List<string>();

        private readonly Dictionary<string, GraphqlTemplate> _fragments;

        public GraphqlTemplate(string name, TemplateType templateType, string[] contents,
            Dictionary<string, GraphqlTemplate> fragments)
        {
            Name = name;
            TemplateType = templateType;
            Contents = ParseContents(contents);
            _fragments = fragments;
        }

        private string ParseContents(string[] contents)
        {
            var builder = new StringBuilder();

            foreach (var line in contents)
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith(ParameterToken))
                {
                    Parameters.Add(line);
                }
                else if (!string.IsNullOrWhiteSpace(trimmed))
                {
                    if (trimmed.StartsWith(FragmentToken))
                    {
                        ReferencedFragments.Add(trimmed.Replace(FragmentToken, EmptyString));
                    }

                    builder.Append(line).AppendLine();
                }
            }

            return builder.ToString();
        }

        internal void Compile()
        {
            if (TemplateType == TemplateType.Fragment) return;

            var parameters = new List<string>(Parameters);
            var processedFragments = new List<string>();
            var fragmentQueue = new Stack<GraphqlTemplate>();
            var builder = new StringBuilder(Contents).AppendLine();
            
            foreach (var fragment in ReferencedFragments)
            {
                fragmentQueue.Push(_fragments[fragment]);
            }

            while (fragmentQueue.Count > 0)
            {
                var template = fragmentQueue.Pop();

                if (processedFragments.Contains(template.Name)) continue;
                
                foreach (var fragment in template.ReferencedFragments)
                {
                    fragmentQueue.Push(_fragments[fragment]);
                }
                
                foreach (var parameter in template.Parameters.Where(parameter => !parameters.Contains(parameter)))
                {
                    parameters.Add(parameter);
                }

                builder.Append(template.Contents).AppendLine();
                processedFragments.Add(template.Name);
            }

            var replaceTerm = TemplateType.ToString().ToLower();
            var formattedParams = string.Join(CommaSpaceDelimiter, parameters);
            CompiledContents = builder.ToString().Replace(replaceTerm, $"{replaceTerm} {Name}({formattedParams})");
        }
    }
}