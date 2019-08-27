using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependenciesvManagerv2
{
    class MenuPrincipal
    {
        /*public void listAll ()
        {

            List<configuration_items> allItems = CIM.GetAllConfiguratioItems();
            foreach (configuration_items i in allItems)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Nombre del CI: " + i.name_ci);
                Console.WriteLine("Descripcion: " + i.description_ci);
                Console.WriteLine("Descripcion: " + i.version_ci);
                Console.WriteLine("------------------------");




            }
        }*/
        

        static void Main(string[] args)
        {

            while (true)
            {
                CIManager CIM = new CIManager();
                Console.WriteLine("Bienvenido al  CI manager");
                Console.WriteLine("Elija la opción a realizar");
                Console.WriteLine("1. Agregar CI");
                Console.WriteLine("2. Editar CI");
                Console.WriteLine("3. Eliminar CI");
                Console.WriteLine("4. Visualizar CI");
                Console.WriteLine("5. Agregar dependencia a CI");
                Console.WriteLine("6. Eliminar dependencia a CI");
                Console.WriteLine("7. Listar todos los CI");
                Console.WriteLine("8. Salir");

                int option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre del Configuration Item");
                        String name = Console.ReadLine();
                        Console.WriteLine("Ingrese la descripción del Configuration Item");
                        String description = Console.ReadLine();
                        Console.WriteLine("Ingrese el major number");
                        int major = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el minor number");
                        int minor = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el patch number");
                        int patch = Convert.ToInt32(Console.ReadLine());

                        String complete_version_numbers = major + "." + minor + "." + patch;

                        CIM.InsertCI(name, description, complete_version_numbers);
                        Console.WriteLine();
                        Console.WriteLine("Configuration item agregado correctamente");
                        break;

                      case 2:
                        Console.WriteLine("Escriba el nombre del CI que desea editar:");
                        string ci_name = Console.ReadLine();
                         CIM.EditCI(ci_name);
                        break;

                      case 3:
                     //     CIM.DeleteCI();
                          break;

                      case 4:
                        Console.WriteLine("Ingrese el nombre del CI: ");
                        String nameCi = Console.ReadLine();
                          configuration_items ci=  CIM.GetConfiguratioItemByName(nameCi);

                        if (ci == null)
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine("Nombre inválido");
                            Console.WriteLine("------------------------");
                        }
                        else
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine("Nombre del CI: " + ci.name_ci);
                            Console.WriteLine("Descripcion: " + ci.description_ci);
                            Console.WriteLine("Descripcion: " + ci.version_ci);
                            Console.WriteLine("------------------------");
                        }
                          break;

                      case 5:
                        Console.WriteLine("Seleccione el configuration item: ");
                         String CiName = Console.ReadLine();
                        Console.WriteLine("Selecciona la dependencia: ");
                        String DepName   = Console.ReadLine();
                        if (CIM.GetConfiguratioItemByName(CiName)!= null && CIM.GetConfiguratioItemByName(DepName) !=null)
                        {
                            CIM.InsertDependency(CiName,DepName);
                        }
                     else
                        {
                            Console.WriteLine("Nombre inválido");
                        }
                        break;

                      case 6:
                       //   CIM.DeleteDependencyCI();
                          break;

                      case 7:
                        List<configuration_items> allItems = CIM.GetAllConfiguratioItems();
                        foreach (configuration_items i in allItems)
                        {
                            Console.WriteLine("------------------------");
                            Console.WriteLine("Nombre del CI: "+i.name_ci);
                            Console.WriteLine("Descripcion: "+i.description_ci);
                            Console.WriteLine("Descripcion: " + i.version_ci);
                            Console.WriteLine("------------------------");




                        }
                          break;

                    case 8:
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Ingrese una opción válida");
                        Console.WriteLine("------------------------");
                        break;
                }
            }
          
        }
    }
}
