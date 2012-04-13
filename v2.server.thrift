
include "v2.client.thrift"

namespace csharp VersionExample

service ServerService extends v2.client.ClientService {
  bool foo()
}
