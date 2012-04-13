using Thrift.Protocol;
using Thrift.Transport;
using VersionExample;

namespace v1server
{
    public class ServiceHttpHandler : THttpHandler
    {
        public ServiceHttpHandler()
            : base(CreateProcessor(), CreateJsonFactory())
        {
        }

        private static ServerService.Processor CreateProcessor()
        {
            return new ServerService.Processor(new ServiceImplementation());
        }

        private static TJSONProtocol.Factory CreateJsonFactory()
        {
            return new TJSONProtocol.Factory();
        }
    }
}