using System.Reflection;

namespace hunter_repository.Extensions
{
    public static class Resources
    {
        public static string Get(string query)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"hunter-repository.{query}.sql"))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException($"Query não encontrada {query}");
                }

                using (var reader = new StreamReader(stream))
                {
                    string queryResult;

                    if (reader.BaseStream.Length > int.MaxValue)
                    {
                        throw new FileNotFoundException($"File exceded maximum size: {reader.BaseStream.Length}");
                    }
                    else
                    {
                        queryResult = reader.ReadToEnd();
                    }
                    return queryResult;
                }
            }
        }
    }
}
