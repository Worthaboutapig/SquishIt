using System;
using System.Web.Caching;

namespace SquishIt.Tests.Helpers
{
	public class HttpRuntimeScope : IDisposable
    {
		public HttpRuntimeScope(string appDomainAppPath, string appDomainAppVirtualPath, Cache cache)
        {
			Framework.HttpRuntime.appDomainAppPath = appDomainAppPath;
			Framework.HttpRuntime.appDomainAppVirtualPath = appDomainAppVirtualPath;
			Framework.HttpRuntime.cache = cache;
		}

        public void Dispose()
        {
			Framework.HttpRuntime.appDomainAppPath = null;
			Framework.HttpRuntime.appDomainAppVirtualPath = null;
			Framework.HttpRuntime.cache = null;
        }
    }
}
