using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EnjinSDK.Graphql
{
    public class GraphqlQueryRegistry
    {
        private const string FragmentId = "Fragment";
        private const string MutationId = "Mutation";
        private const string QueryId = "Query";

        private static readonly Regex TemplateRegex =
            new Regex("^(?:[.a-zA-Z]{0,}\\.)(?<query>[a-zA-Z]{1,}?(?<type>Fragment|Mutation|Query))\\.gql$");

        private Dictionary<string, GraphqlTemplate> _fragments = new Dictionary<string, GraphqlTemplate>();
        private Dictionary<string, GraphqlTemplate> _operations = new Dictionary<string, GraphqlTemplate>();

        public GraphqlQueryRegistry()
        {
            RegisterSdkTemplates();
        }
        
        private string[] LoadTemplateContents(Assembly assembly, string name)
        {
            using (var stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null) return null;
                using (var reader = new StreamReader(stream))
                {
                    List<string> contents = new List<string>();

                    while (!reader.EndOfStream)
                    {
                        contents.Add(reader.ReadLine());
                    }

                    return contents.ToArray();
                }
            }
        }

        private void LoadAndCacheTemplateContents(Assembly assembly, string name, string query, TemplateType templateType)
        {
            var contents = LoadTemplateContents(assembly, name);

            if (contents == null) return;

            switch (templateType)
            {
                case TemplateType.Fragment:
                    _fragments.Add(query, new GraphqlTemplate(query, templateType, contents, _fragments));
                    break;
                case TemplateType.Mutation:
                case TemplateType.Query:
                    _operations.Add(query, new GraphqlTemplate(query, templateType, contents, _fragments));
                    break;
            }
        }

        private void LoadTemplatesInAssembly(Assembly assembly)
        {
            foreach (var name in assembly.GetManifestResourceNames())
            {
                var match = TemplateRegex.Match(name);
                if (!match.Success) continue;
                var query = match.Groups["query"].Value;
                var typeParseResult = Enum.TryParse(match.Groups["type"].Value, true, out TemplateType type);

                if (!typeParseResult) continue;

                LoadAndCacheTemplateContents(assembly, name, query, type);
            }

            foreach (var operation in _operations.Values)
            {
                operation.Compile();
            }
        }

        public void RegisterTemplatesInAssembly(Assembly assembly)
        {
            LoadTemplatesInAssembly(assembly);
        }

        internal void RegisterSdkTemplates()
        {
            RegisterTemplatesInAssembly(Assembly.GetExecutingAssembly());
        }

        public GraphqlTemplate GetOperationForName(string name)
        {
            return _operations.ContainsKey(name) ? _operations[name] : null;
        }
    }
}