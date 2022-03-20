using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrafanaSensorServer.Infra
{
    public interface ISensor<T>
    {
        public string Name { get; set; }
        public Task RegisterValueAsync(T value);
    }
}
