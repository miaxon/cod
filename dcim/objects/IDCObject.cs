using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcim.objects
{
    public interface IDCObject
    {
        void fromArray(object[] values);
    }
}
