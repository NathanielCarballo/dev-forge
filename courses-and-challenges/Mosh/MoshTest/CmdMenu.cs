using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace MoshTest
{
    public class CmdMenu
    {
        private static List<Type> GetClassTypes()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes(); 

            List<Type> classTypes = types.Where(t => t.IsClass).ToList();

            return classTypes;
        }

        private static MethodInfo[] GetMethods(Type classType)
        {
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Static);

            return methods;
        }

        private static void DisplayClassMenu(List<Type> classTypes)
        {
            Console.WriteLine("Available Classes: ");

            for (int i = 0; i < classTypes.Count; i++) 
            {
                Console.WriteLine($"{i + 1}. {classTypes[i].Name}");
            }

            Console.WriteLine();
            Console.WriteLine("Enter the number of the class to select: ");

        }

        private static void DisplayMethodMenu(Type classType, MethodInfo[] methods)
        {

            Console.WriteLine($"Selected Class: {classType.Name}");
            Console.WriteLine("Available Methods: ");

            for(int i = 0; i < methods.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {methods[i].Name}");
            }

            Console.WriteLine();
            Console.WriteLine("Enter the number of the method to invoke: ");
        
        }

        private static void InvokeMethod(Type classType, MethodInfo method)
        {
            object instance = Activator.CreateInstance(classType);

            method.Invoke(null, null);

            Console.WriteLine("Method invoked successfully");

        }
        
        public static void Run()
        {
            List<Type> classTypes = GetClassTypes();

            DisplayClassMenu(classTypes);

            if(int.TryParse(Console.ReadLine(), out int classSelection) && classSelection > 0 && classSelection <= classTypes.Count)
            {
                Type selectedClassType = classTypes[classSelection - 1];

                MethodInfo[] methods = GetMethods(selectedClassType);

                DisplayMethodMenu(selectedClassType, methods);

                if(int.TryParse(Console.ReadLine(),out int methodSelection) && methodSelection > 0 && methodSelection <= methods.Length) 
                {

                    MethodInfo selectedMethod = methods[methodSelection - 1];
                    InvokeMethod(selectedClassType, selectedMethod);
                
                }
                else
                {
                    Console.WriteLine("Invalid method selection.");
                }
            }
            else
            {
                Console.WriteLine("Invalid class selection.");
            }
        }
    }

}
