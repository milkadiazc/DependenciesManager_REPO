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

        public List<configuration_items> GetAllConfiguratioItems ()
        {
            List<configuration_items> itemList = new List<configuration_items>();

            using (CIDBEntities db = new CIDBEntities())
            {
                itemList = db.configuration_items.ToList();

            }

                return itemList;
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

        public configuration_items GetConfiguratioItemByName(String CiName)
        {
            configuration_items ci_ret = null;

            using (CIDBEntities cb = new CIDBEntities())
            {
               ci_ret =  cb.configuration_items.Find(CiName);
            }

            return ci_ret;
        }

        public void InsertDependency (String ci_father, String ci_child)
        {
            CIDBEntities db = new CIDBEntities();
            db.Database.ExecuteSqlCommand(@"insert into dependencies_ci (name_ci_father,name_ci_child)values({0},{1})",ci_father,ci_child);
            db.SaveChanges();
        }
    }
}
