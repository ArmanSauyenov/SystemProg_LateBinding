using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace CloudService
{
    class Program
    {
        static object ExecuteLateBindedMethod(
            string pathToAssembly, 
            string fullClassName, 
            string methodName,
            object [] arguments)
        {
            Assembly loadedAssembly = Assembly.LoadFile(pathToAssembly);
            Type lateBindedType = loadedAssembly.GetType(fullClassName);

            if (lateBindedType != null)
            {
                // Late-binded instance
                Object instance = Activator.CreateInstance(lateBindedType);

                MethodInfo method = instance
                    .GetType()
                    .GetMethod(methodName);

                /*
                    MethodInfo [] methods = instance
                    .GetType()
                    .GetMethods();       
                 */

                return method.Invoke(instance, arguments);
            }
            else return null;
        }
        static void Main(string[] args)
        {
            /*
            var serializedObject = JsonConvert.SerializeObject("alfar@gmail.com");

            AppDomain currentDomain = AppDomain.CurrentDomain;

            foreach (var assembly in currentDomain.GetAssemblies())
            {
                Console.WriteLine(assembly.FullName);
            } */

            // Early binding - before compile time
            //DateTimeProvider provider = new DateTimeProvider();
            // Console.WriteLine(provider.GetCurrentDayOfWeek());

            #region Late Binding

            /*
            string pathToAssembly = @"C:\ExternalLibrary.dll";

            ExecuteLateBindedMethod(pathToAssembly, "ExternalLibrary.DateTimeProvider", "GetDayOfWeek");
            */

            /*
            while (true)
            {
                Console.WriteLine("Enter assembly to add:");
                string assemblyName = Console.ReadLine();
                Console.WriteLine("Enter type full name to add:");
                string typeName = Console.ReadLine();
                Console.WriteLine("Enter method to add:");
                string methodName = Console.ReadLine();
                Console.WriteLine("Enter arguments to add separated");
                string arguments = Console.ReadLine();

                var integers = arguments
                    .Split(' ')
                    .Select(p => int.Parse(p))
                    .Cast<object>()
                    .ToArray();

                object result = ExecuteLateBindedMethod(assemblyName, typeName, methodName, integers);

                Console.WriteLine(result);
            }
            */
            #endregion

            Array arr = new int[] { 1, 2, 3, 4, 5 };
            
            Console.WriteLine(arr.GetType().FullName);

            Console.ReadLine();
        }
    }
}
