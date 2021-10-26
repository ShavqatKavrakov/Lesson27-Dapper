using System;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
namespace Lesson27
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("1. Получение всех машин\n2. Получение определённой машин\n3. Добовить машину\n4. Удалить машину\n5. Обновить машину\n6. Выйти");
                Console.WriteLine("Введите команда:");
                int n = int.Parse(Console.ReadLine());
                switch(n)
                {
                    case 1: ReadAll(); break;
                    case 2: await Read(); break;
                    case 3: await Insert();break;
                    case 4: await Delete();break;
                    case 5: await Update(); break;
                    case 6: return;
                }
            }
        }
        private static async Task Insert()
        {
            var car = new Car();
            Console.WriteLine("Введите название машины:");
            car.Name = Console.ReadLine();
            var user = await CRUD.Read(car.Name);
            if (user == null)
            {
                Console.WriteLine("Введите цена машина:");
                car.Price = int.Parse(Console.ReadLine());
                if (await CRUD.Insert(car))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Машина успешно добовилось");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Машина {car.Name}  уже есть");
                Console.ResetColor();
            }
        }
        private static async Task Read()
        {
            Console.WriteLine("Введите название машины:");
            string name = Console.ReadLine();
            var car = await CRUD.Read(name);
           
            if (car != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(car.ToString());
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Машина не найдено");
                Console.ResetColor();
            }
        }
        private static void ReadAll()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach(var item in CRUD.ReadAll())
                Console.WriteLine(item.ToString());
            Console.ResetColor();
        }
            private static async Task Update()
            {
                var car = new Car();
                Console.WriteLine("Введите название машины:");
               string name = Console.ReadLine();
                var user = await CRUD.Read(name);
                if (user != null)
                {
                Console.WriteLine("Введите новые название машины:");
               string newname = Console.ReadLine();
                    if (await CRUD.Update(name,newname))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Машина успешно онбовилось");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Машина не найдено");
                    Console.ResetColor();
                }
            }
        private static async Task Delete()
        {
            Console.WriteLine("Введите название:");
            string name = Console.ReadLine();
            var user = await CRUD.Read(name);
            if (user != null)
            {
                if (await CRUD.Delete(name))
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Машина успешно удалён");
                    Console.ResetColor();
                }   
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Машина не найдено");
                Console.ResetColor();
            }
        }

    }


}

