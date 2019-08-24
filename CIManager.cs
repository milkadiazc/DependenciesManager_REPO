using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependenciesvManagerv2
{
    class CIManager
    {
      
        public void InsertCI(String name, String description, String version)
        {
            using(CIDBEntities cb = new CIDBEntities())
            {
                var obj = new configuration_items();
                obj.name_ci = name;
                obj.description_ci = description;
                obj.version_ci = version;

                cb.configuration_items.Add(obj);
                cb.SaveChanges();
            }

        }
    }
}
