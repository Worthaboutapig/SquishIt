namespace SquishIt.Framework.Invalidation
{
	using System.IO;

	public class DefaultCacheInvalidationStrategy : ICacheInvalidationStrategy
    {
        public string GetOutputFileLocation(string outputFile, string hash)
        {
	        var filename = Path.GetFileName(outputFile);
	        
			if (!filename.Contains("#")) return outputFile;

	        var hashedFileName = filename.Replace("#", hash);
	        var result = Path.Combine(Path.GetDirectoryName(outputFile), hashedFileName);
	        return result;
        }

        public string GetOutputWebPath(string renderToPath, string hashKeyName, string hash)
        {
			var filename = Path.GetFileName(renderToPath);
			if (filename.Contains("#"))
            {
				var hashedFileName = filename.Replace("#", hash);
				var result = Path.Combine(Path.GetDirectoryName(renderToPath), hashedFileName);
				return result;
            }

            if (!string.IsNullOrEmpty(hashKeyName))
            {
                return renderToPath + (renderToPath.Contains("?") ? "&" : "?") + hashKeyName + "=" + hash;
            }
            return renderToPath;
        }
    }
}