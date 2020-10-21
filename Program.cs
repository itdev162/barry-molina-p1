using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace InventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // CreateDB db = new CreateDB();
            Manager manager = new Manager();

            // db.InitiateDb();
            manager.MainMenu();
        }
    }
}
