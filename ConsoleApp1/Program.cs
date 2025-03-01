using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    public class MAIN_CLASS
    {
        static void Main()
        {
            Ex2_4 ex;
            InventoryItems items = new InventoryItems();
            do
            {
                ex = new Ex2_4();
                Console.WriteLine("\nWelcome to My Shop\nMaster Inventory\n1.Add Product\n2.Delete Product using Product Name\n3.Update Product Using Product Name\n4.View All Products\n5.View Perishable Products\n6.View Non Perishable Products\n7.Purchase Products\n8.Refund Products\n9.Exit\n\nEnter your option:");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    Console.WriteLine("Yaaah you are on the right way to add new item to the inventory!");
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
                    
                }
                else if (opt == 3)
                {
                    items.viewProductsName();
                    Console.WriteLine("Update your product using product name\n");
                    items.update(ex);
                    
                }
                else if (opt == 4)
                {
                    items.GetProductDetails();
                }
                else if (opt == 5)
                {
                    items.classifyProducts();
                    items.ViewPerishableItems();

                }
                else if (opt == 6)
                {
                    items.classifyProducts();
                    items.ViewNonPerishableItems();
                }
                else if (opt == 7)
                {   
                    items.SellItem();
                }
                else if (opt == 8)
                {
                    items.RefundItem();
                }
                else if (opt == 9)
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