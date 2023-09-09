using System;
using AppBarLib.Core;

namespace Scripts.AppBarLib.Core
{
    internal interface IConcern : IDisposable
    {
        public Context Context { get; }
    }
}