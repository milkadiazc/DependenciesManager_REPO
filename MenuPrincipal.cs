using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependenciesvManagerv2
{
    class MenuPrincipal
    {
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
                     //     CIM.ViewCI();
                          break;

                      case 5:
                        //  CIM.AddDependencyCI();
                          break;

                      case 6:
                       //   CIM.DeleteDependencyCI();
                          break;

                      case 7:
                      //    CIM.ViewAllCI();
                          break;

                    case 8:
                        System.Environment.Exit(0);
                        break;
                }
            }
            Console.Read();
        }
    }
}
