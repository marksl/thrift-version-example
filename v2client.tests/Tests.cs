using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Thrift.Protocol;
using Thrift.Transport;
using VersionExample;

namespace v2client.tests
{
    [TestClass]
    public class Tests
    {
        private const string Version2Url = "http://localhost:102/service.thrift";

        [TestMethod]
        public void v2client_call_rpc_v2server()
        {
            ClientService.Iface client = Create(Version2Url);

            call_rpc(client);
        }

        private void call_rpc(ClientService.Iface client)
        {
            // This no longer compiles after updating to the latest Client.thrift file.
            //bool foo = client.foo();

            bool negativeNumbersReturnFalse = client.fooEx(-1);
            Assert.IsFalse(negativeNumbersReturnFalse);
            
            bool positiveNumbersReturnTrue = client.fooEx(1);
            Assert.IsTrue(positiveNumbersReturnTrue);

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