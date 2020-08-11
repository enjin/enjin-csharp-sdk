using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Enjin.SDK.Graphql
{
    [PublicAPI]
    public class GraphqlQueryRegistry
    {
        private static readonly Regex TEMPLATE_REGEX =
            new Regex(new StringBuilder("^(?:[.a-zA-Z]{0,}\\.)") // Handles arbitrary number of path elements.
                .Append("schemas\\.(?:project|player|shared)\\.") // Validate schema.
                .Append("(?<type>fragment|mutation|query)\\.") // Gets the template type.
                .Append("(?:[a-zA-Z]{1,}?)\\.gql$") // Validates the query name.
                .ToString());

        private readonly Dictionary<string, GraphqlTemplate> _fragments = new Dictionary<string, GraphqlTemplate>();
        private readonly Dictionary<string, GraphqlTemplate> _operations = new Dictionary<string, GraphqlTemplate>();

        public GraphqlQueryRegistry()
        {
            RegisterSdkTemplates();
        }

        private static string[] LoadTemplateContents(Assembly assembly, string name)
        {
            using (var stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null) return null;
                using (var reader = new StreamReader(stream))
                {
                    var contents = new List<string>();

                    while (!reader.EndOfStream)
                    {
                        contents.Add(reader.ReadLine());
                    }

                    return contents.ToArray();
                }
            }
        }

        private void LoadAndCacheTemplateContents(string[] contents, TemplateType templateType)
        {
            if (contents == null)
                return;
            
            var id = GraphqlTemplate.ReadNamespace(contents);
            if (id == null)
                return;
            
            if (templateType == TemplateType.FRAGMENT)
                _fragments.Add(id, new GraphqlTemplate(id, templateType, contents, _fragments));
            else if (templateType == TemplateType.MUTATION || templateType == TemplateType.QUERY)
                _operations.Add(id, new GraphqlTemplate(id, templateType, contents, _fragments));
        }

        private void LoadTemplatesInAssembly(Assembly assembly)
        {
            foreach (var name in assembly.GetManifestResourceNames())
            {
                var match = TEMPLATE_REGEX.Match(name);
                if (!match.Success)
                    continue;
                
                var type = match.Groups["type"].Value;
                if (Enum.TryParse(type, true, out TemplateType templateType))
                    LoadAndCacheTemplateContents(LoadTemplateContents(assembly, name), templateType);
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