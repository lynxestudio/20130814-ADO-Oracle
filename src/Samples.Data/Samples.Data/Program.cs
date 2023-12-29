using System;

namespace Samples.Data {
    class Program    {
        static void Main(string[] args) {
            CustomerManager manager = new CustomerManager();
            Console.WriteLine("Oracle ADO.NET Data Helper example");
            Console.WriteLine("Create a new customer.");
            Console.Write("\tCustomer id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tCustomer name: ");
            string name = Console.ReadLine();
            Console.Write("\tCustomer surname: ");
            string surname = Console.ReadLine();
            Console.Write("\tCustomer address: ");
            string address = Console.ReadLine();
            Console.Write("\tCustomer phone: ");
            string phone = Console.ReadLine();
            Console.Write("\tCustomer email: ");
            string email = Console.ReadLine();
            manager.Create(new Customer { 
                Id = id,
                Name = name,
                Surname = surname,
                Address = address,
                Phone = phone,
                Email = email
            });
            Console.Write("Retrieve a customer by id, enter id: ");
            id = Convert.ToInt32(Console.ReadLine());
            Customer customer = manager.Retrieve(id);
            Console.WriteLine("{0}",customer.ToString());
            Console.WriteLine("Update the customer's name and email");
            customer.Name = "Oracle corporation.";
            customer.Email = "ado@oracle.net";
            manager.Update(customer);
            Console.WriteLine("Retrieve the updated customer.");
            customer = manager.Retrieve(id);
            Console.WriteLine("{0}", customer.ToString());
            Console.ReadLine();
        }
    }
}