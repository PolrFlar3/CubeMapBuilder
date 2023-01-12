using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeMap_BUILDER_
{
    class UUIDHandling
    {
        public static string getUUID()
        {
            Guid uuid = Guid.NewGuid();
            string uuid_ = uuid.ToString();
            uuid_ = uuid_.Remove(8, 28);

            return uuid_;
        }
    }
}
