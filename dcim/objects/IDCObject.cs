using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcim.objects
{
    public interface IDCObject
    {
        void FromArray(object[] values);
        int ObjectTypeID { get; }
        int ObjectID { get; }
        string ObjectName { get; }
        string ObjectFullName { get; }
        string ObjectInfo { get; }
        bool HasError { get; }
    }
}
