using System.Collections.Generic;
using VersionExample;

namespace v1server
{
    public class ServiceImplementation : ServerService.Iface
    {
        private readonly Dictionary<int, ServerService> log;

        public ServiceImplementation()
        {
            log = new Dictionary<int, ServerService>();
        }

        public bool foo()
        {
            return true;
        }

        public bool bar()
        {
            return true;
        }
    }
}