using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Enjin.SDK.Utils.TextFormatting;

namespace Enjin.SDK.Graphql
{
    public enum TemplateType
    {
        FRAGMENT,
        MUTATION,
        QUERY
    }

    public class GraphqlTemplate
    {
        internal const string NAMESPACE_KEY = "#namespace";
        internal const string IMPORT_KEY = "#import";
        internal const string ARG_KEY = "#arg";

        public string NameSpace { get; }
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

                builder.Append(template.Contents).AppendLine();
                processedFragments.Add(template.NameSpace);
            }

            var replaceTerm = TemplateType.ToString().ToLower();
            var formattedParams = string.Join(CommaSpaceDelimiter, parameters);
            CompiledContents = builder.ToString().Replace(replaceTerm, $"{replaceTerm} {Name}({formattedParams})");
        }

        internal static string ReadNamespace(IEnumerable<string> contents)
        {
            return (from line in contents
                    where line.StartsWith(NAMESPACE_KEY)
                    select line.Split(' ')[1])
                .FirstOrDefault();
        }

        private static string ProcessArg(string line)
        {
            var parts = line.Split(' ');

            switch (parts.Length)
            {
                case 3:
                    return $"${parts[1]}: {parts[2]}";
                case 4:
                    return $"${parts[1]}: {parts[2]} = {parts[3]}";
                default:
                    return null;
            }
        }

        private static string ProcessImport(string line)
        {
            return line.Split(' ')[1];
        }
    }
}