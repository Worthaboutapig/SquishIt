using System;
using System.IO;

namespace SquishIt.Framework
{
    public class PathTranslator : IPathTranslator
    {
        public string ResolveAppRelativePathToFileSystem(string file)
        {
	        // Remove query string
            if (file.IndexOf('?') != -1)
            {
                file = file.Substring(0, file.IndexOf('?'));
            }

	        if (HttpContext.Current == null)
	        {
		        return ProcessWithoutHttpContext(file);
	        }

	        return HttpContext.Current.Server.MapPath(HttpRuntime.AppDomainAppVirtualPath + "/" + file.TrimStart("~/").TrimStart("~"));
        }

	    static string ProcessWithoutHttpContext(string file)
        {
            file = Platform.Unix 
                ? file.TrimStart('~', '/') // does this need to stay this way to account for multiple leading slashes or can string trimstart be used?
                : file.Replace("/", "\\").TrimStart('~').TrimStart('\\');

            return Path.Combine(Environment.CurrentDirectory, file);
        }

        public string ResolveFileSystemPathToAppRelative(string file)
        {
	        Uri root;
            
			if (HttpContext.Current == null)
            {
				root = new Uri(Environment.CurrentDirectory);
				var path = root.MakeRelativeUri(new Uri(file, UriKind.RelativeOrAbsolute)).ToString();
				return path.Substring(path.IndexOf("/", StringComparison.InvariantCulture) + 1);
			}
	        
			root = new Uri(HttpRuntime.AppDomainAppPath);
			return root.MakeRelativeUri(new Uri(file, UriKind.RelativeOrAbsolute)).ToString();
        }
    }
}
