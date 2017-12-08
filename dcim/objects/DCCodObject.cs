using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static dcim.Program;
namespace dcim.objects
{
    public class DCCodObject : DCObject
    {
        public DCCodObject()
        {
            TypeId = enums.DCType.Cod;
        }

        public static DCCodObject Get(int id)
        {
            string query = string.Format("call cod_get({0}, '{1}')", id, null);
            DCCodObject result = DataProvider.GetObject<DCCodObject>(query);
            return result;
        }

        public static DCCodObject Get(string name)
        {
            string query = string.Format("call cod_get({0}, '{1}')", -1, name);
            DCCodObject result = DataProvider.GetObject<DCCodObject>(query);
            return result;
        }

        public void Update()
        {
            string query = string.Format("call cod_update({0},'{1}','{2}','{3}')",
                Id, Name, FullName, Info);
            DataProvider.Update(query);
        }

        public void Create()
        {
            string query = string.Format("call cod_create('{0}','{1}','{2}')",
                Name, FullName, Info);
            DataProvider.Update(query);
        }
        public static void Delete(int id)
        {
            string query = string.Format("call cod_delete({0})", id);
            DataProvider.Update(query);
        }
    }
}
