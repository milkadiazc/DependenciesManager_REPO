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

        public void DeleteCI(string ci_name1)
        {
           
           
        }

        public void EditCI(string ci_name)
        {
            using (CIDBEntities cb = new CIDBEntities())
            {
                var result = cb.configuration_items.SingleOrDefault(b => b.name_ci == ci_name);
                if(result == null)
                {
                    Console.WriteLine("El CI que intenta modificar no existe");
                }
                else
                {

                    Console.WriteLine("Complete solo los campos que desee modificar");
                    Console.WriteLine("Ingrese la descripción del Configuration Item");
                    String description = Console.ReadLine();
                    Console.WriteLine("Ingrese el major number");
                    string major = Console.ReadLine();
                    Console.WriteLine("Ingrese el minor number");
                    string minor = Console.ReadLine();
                    Console.WriteLine("Ingrese el patch number");
                    string patch = Console.ReadLine();

                    if (!String.IsNullOrEmpty(description))
                    {
                        result.description_ci = description;
                    }

                    if (!String.IsNullOrWhiteSpace(major))
                    {
                        string[] line = result.version_ci.Split('.');
                        if (line[0] != major)
                        {
                            Console.WriteLine("ADVERTENCIA: El cambio en la version puede provocar cambios en las dependencias");
                        }
                        
                        result.version_ci = (String.IsNullOrWhiteSpace(major) ? line[0] : major) + "." + (String.IsNullOrWhiteSpace(minor) ? line[1] : minor) + "." + (String.IsNullOrWhiteSpace(patch) ? line[0] : patch);
                    }
                    else
                    {
                        string[] line = result.version_ci.Split('.');
                        result.version_ci = (String.IsNullOrWhiteSpace(major) ? line[0] : major) + "." + (String.IsNullOrWhiteSpace(minor) ? line[1] : minor) + "." + (String.IsNullOrWhiteSpace(patch) ? line[0] : patch);
                    }
                }

                cb.SaveChanges();
            }

        }
    }
}
