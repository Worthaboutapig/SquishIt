using System.Web.Caching;

namespace SquishIt.Framework
{
	internal class HttpRuntime
	{
		internal static string appDomainAppPath;
		internal static string AppDomainAppPath
		{
			get { return appDomainAppPath ?? System.Web.HttpRuntime.AppDomainAppPath; } 
		}

		internal static string appDomainAppVirtualPath;
		internal static string AppDomainAppVirtualPath
		{
			get { return appDomainAppVirtualPath ?? System.Web.HttpRuntime.AppDomainAppVirtualPath; } 
		}

		internal static Cache cache;
		internal static Cache Cache
		{
			get { return cache ?? System.Web.HttpRuntime.Cache; } 
		}
	}
}