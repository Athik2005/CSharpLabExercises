﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class Sample
    {
        static void Main()
        {
            Ex2_4 ex = new Ex2_4();
            InventoryItems items = new InventoryItems();
            do
            {
                Console.WriteLine("Welcome to My Shop\n1.Add Product\n2.Delete Product using Product Name\n3.Update Product Using Product Name\n4.View All Products\n5.Exit\n\nEnter your option:");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    Console.WriteLine("Yaaah you are on the right way to place order!");
                    Console.Write("Enter the Product Name:");
                    ex.setName(Console.ReadLine());
                    Console.Write("Enter Category of that Product:");
                    ex.setCategory(Console.ReadLine());
                    Console.Write("Enter the Product Type:");
                    ex.setType(Console.ReadLine());
                    items.add(ex);
                }
                else if (opt == 2)
                {
                    items.viewProductsName();
                    Console.WriteLine("Delete your product using product name\n");
                    items.remove(ex);
                    break;
                }
                else if (opt == 3)
                {
                    items.viewProductsName();
                    Console.WriteLine("Update your product using product name\n");
                    items.update(ex);
                    break;
                }
                else if (opt == 4)
                {
                    items.viewProducts();
                }
                else if (opt == 5)
                {
                    Console.WriteLine("Thanks for Booking!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option!");
                    break;
                }
            } while (true);
        } 
    }
}