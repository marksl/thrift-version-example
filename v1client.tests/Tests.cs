using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thrift.Protocol;
using Thrift.Transport;
using VersionExample;

namespace v1client.tests
{
    [TestClass]
    public class Tests
    {
        private const string Version1Url = "http://localhost:101/service.thrift";
        private const string Version2Url = "http://localhost:102/service.thrift";

        [TestMethod]
        public void v1client_call_rpc_v1server()
        {
            ClientService.Iface client = Create(Version1Url);

            call_rpc(client);
        }
        
        [TestMethod]
        public void v1client_call_rpc_v2server()
        {
            ClientService.Iface client = Create(Version2Url);

            call_rpc(client);
        }

        private void call_rpc(ClientService.Iface client)
        {
            bool foo = client.foo();
            Assert.IsTrue(foo);

            bool bar = client.bar();
            Assert.IsTrue(bar);
        }

        ClientService.Iface Create(string uriString)
        {
            var uri = new Uri(uriString);
            var httpClient = new THttpClient(uri);
            var jsonProtocol = new TJSONProtocol(httpClient);
            var client = new ClientService.Client(jsonProtocol);

            return client;
        }
    }
}