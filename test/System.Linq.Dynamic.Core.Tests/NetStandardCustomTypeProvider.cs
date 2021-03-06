﻿using System.Collections.Generic;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using Xunit.Runner.DotNet;

namespace System.Linq.Dynamic.Core.Tests
{
    class NetStandardCustomTypeProvider : AbstractDynamicLinqCustomTypeProvider, IDynamicLinkCustomTypeProvider
    {
        public HashSet<Type> GetCustomTypes()
        {
            var thisType = typeof (Program);
#if NETSTANDARD
            var assemblies = AppDomain.NetCoreApp.AppDomain.CurrentDomain.GetAssemblies(thisType).Where(x => !x.IsDynamic).ToArray();
#else
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
#endif

            return new HashSet<Type>(FindTypesMarkedWithDynamicLinqTypeAttribute(assemblies));
        }
    }
}