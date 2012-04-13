using VersionExample;

namespace v2server
{
    public class ServiceImplementation : ServerService.Iface
    {
        public bool fooEx(int num)
        {
            return num > 0;
        }

        public bool bar()
        {
            return true;
        }

        public bool foo()
        {
            return true;
        }
    }
}