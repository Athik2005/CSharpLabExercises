using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_Sharp
{
    abstract public class Item
    {
        abstract public void add(Ex2_4 item);
        abstract public void remove(Ex2_4 item);
        abstract public void search(Ex2_4 item);
        abstract public void update(Ex2_4 item);
        abstract public void GetProductDetails();

    }
    interface ISellable
    {
        public void SellItem();
        public void RefundItem();
    }
    public class Ex2_4()
    {
        private String name;
        private String category;
        private String stock;
        private string ProductID;
        private String ExpiryDate = "None";
        private int StockQuantity;
        public string getExpiryDate()
        {
            return ExpiryDate;
        }
        public void setExpiryDate(String ExpiryDate)
        {
            this.ExpiryDate = ExpiryDate;
        }
        public String getName()
        {
            return name;
        }
        public String getCategory()
        {
            return category;
        }
        public String getProductID()
        {
            return ProductID;
        }
        public void setProductID(String ProductID)
        {
            this.ProductID = ProductID;
        }
        public void setStockQuantity(int StockQuantity)
        {
            this.StockQuantity = StockQuantity;
        }
        public int getStockQuantity()
        {
            return StockQuantity;
        }
        public String getStock()
        {
            return stock;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public void setCategory(String category)
        {
            this.category = category;
        }
        public void setType(String type)
        {
            this.stock = type;
        }
        public override string ToString()
        {
            if (ExpiryDate != null)
                return "Name : " + name + "\nCategory : " + category + "\nStock Quantity : " + StockQuantity + "\nProductID : " + ProductID + "\nExpiry Date :" + ExpiryDate;
            return "Name : " + name + "\nCategory : " + category + "\nStock Quantity : " + StockQuantity + "\nProductID : " + ProductID;
        }
    }
    public class InventoryItems : Item, ISellable
    {
        public List<Ex2_4> firstlist = new List<Ex2_4>();
        public string ProductID;
        public int StockQuantity;
        public string exp = "N";
        List<String> prnames = new List<string>();
        List<String> cancelled = new List<string>();
        bool flag = false;
        private PerishableItem perishableItemList = new PerishableItem();
        private NonPerishableItem nonPerishableItemList = new NonPerishableItem();
        public override void add(Ex2_4 item)
        {
            Console.Write("Enter The Quantity of Product: ");
            StockQuantity = int.Parse(Console.ReadLine());

            Console.Write("Enter Y if your product has Expiry Date: ");
            exp = Console.ReadLine();

            if (exp != "N")
            {
                item.setExpiryDate(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("So I hope your product doesn't have Expiry date!\n");
            }

            item.setStockQuantity(StockQuantity);
            item.setProductID(setProductId(item.getName(), item.getCategory()));
            firstlist.Add(item);

            Console.WriteLine("Product has been added successfully!");
        }
        public static string setProductId(string name, string category)
        {
            return name + "_" + category + " my product!";
        }

        public override void GetProductDetails()
        {
            if (firstlist.Count > 0)
            {
                Console.WriteLine("\nList of Products!\n");
                foreach (var product in firstlist)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("No Products Available.");
            }
        }
        public void viewProductsName()
        {
            if (firstlist.Count > 0)
            {
                Console.WriteLine("\nList of Products!\n");
                for(int i = 0; i < firstlist.Count; i++)
                {
                    Console.WriteLine(firstlist[i].getName());
                }
            }
            else
            {
                Console.WriteLine("No Products Available.");
            }
        }
        public override void remove(Ex2_4 item)
        {
            Console.Write("Enter the Product Name to Remove: ");
            string name = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < firstlist.Count; i++)
            {
                if (firstlist[i].getName().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    firstlist.RemoveAt(i);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Product not found!");
            }
            else
            {
                Console.WriteLine("Product removed successfully.");
            }
        }
        public override void search(Ex2_4 item)
        {
            Console.Write("Enter the Product Name to Search: ");
            string name = Console.ReadLine();
            bool found = false;
            int quantity = 0;

            for (int i = 0; i < firstlist.Count; i++)
            {
                if (firstlist[i].getName().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    quantity = firstlist[i].getStockQuantity();
                }
            }

            if (!found)
            {
                Console.WriteLine("Product not found!");
            }
            else
            {
                Console.WriteLine("Product Exists & Its Quantity is " + quantity);
            }
        }

        public override void update(Ex2_4 item)
        {
            Console.Write("Enter the Product Name to Update: ");
            string name = Console.ReadLine();
            bool found = false;

            for (int i = 0; i < firstlist.Count; i++)
            {
                if (firstlist[i].getName().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    found = true;
                    Console.Write("1. Update Product Name\n2. Update Quantity\n3. Update Category\n\nEnter a valid option: ");
                    int opt = int.Parse(Console.ReadLine());

                    if (opt == 1)
                    {
                        Console.WriteLine("Old Product Name: " + firstlist[i].getName());
                        Console.Write("Enter New Product Name: ");
                        firstlist[i].setName(Console.ReadLine());
                    }
                    else if (opt == 2)
                    {
                        Console.WriteLine("Old Quantity: " + firstlist[i].getStockQuantity());
                        Console.Write("Enter New Quantity: ");
                        firstlist[i].setStockQuantity(int.Parse(Console.ReadLine()));
                    }
                    else if (opt == 3)
                    {
                        Console.WriteLine("Old Category: " + firstlist[i].getCategory());
                        Console.Write("Enter New Category: ");
                        firstlist[i].setCategory(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option!");
                    }
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Product not found!");
            }
            else
            {
                Console.WriteLine("Product Updated Successfully!");
            }
        }
        public void classifyProducts()
        {
            foreach (var item in firstlist)
            {
                if (item.getExpiryDate() != "None" && item.getExpiryDate() != null)
                {
                    perishableItemList.add(item);
                }
                else
                {
                    nonPerishableItemList.add(item);
                }
            }
        }
        public void RefundItem()
        {
            Console.Write("Enter the Product Name : ");
            string pname = Console.ReadLine();
            bool flag = false;
            for (int i = 0; i < firstlist.Count; i++)
            {
                if (firstlist[i].getName() == pname)
                {
                    Console.WriteLine("Refund Quantity for " + pname + " : ");
                    int qty = int.Parse(Console.ReadLine());
                    if (qty > firstlist[i].getStockQuantity())
                    {
                        flag = true;
                        Console.WriteLine("Cant Refund in Negative Numbers!");
                    }
                    if (!flag)
                    {
                        firstlist[i].setStockQuantity(firstlist[i].getStockQuantity() + qty);
                        cancelled.Add(firstlist[i].getName());
                        Console.WriteLine("Replace made successfully!");
                    }
                }
                else
                {
                    Console.WriteLine("No Product Found for " + pname + " !");
                }
            }
        }
        public void SellItem()
        {
            Console.Write("Enter the Product Name : ");
            string pname = Console.ReadLine();
            List<Ex2_4> data = firstlist;
            Console.WriteLine("Searching for " + pname + "!");
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].getName() == pname)
                {
                    Console.WriteLine("Enter the Quantity for " + pname + " : ");
                    int qty = int.Parse(Console.ReadLine());
                    if (qty > data[i].getStockQuantity() || qty < 0)
                    {
                        flag = true;
                        Console.WriteLine("Purchase is more than the Quantity of " + pname);
                    }
                    if (!flag)
                    {
                        data[i].setStockQuantity(data[i].getStockQuantity() - qty);
                        prnames.Add(data[i].getName());
                        Console.WriteLine("Purchase made successfully!");
                    }
                }
                else
                {
                    Console.WriteLine("No Product Found for " + pname + " !");
                }
            }
        }
        public void ViewPerishableItems()
        {
            perishableItemList.ViewPerishItems();
        }

        public void ViewNonPerishableItems()
        {
            nonPerishableItemList.ViewNonPerishableItems();
        }
    }
    public class PerishableItem
    {
        public List<Ex2_4> perishItems = new List<Ex2_4>();
        public void add(Ex2_4 item)
        {
            perishItems.Add(item);
        }
        public void ViewPerishItems()
        {
            if (perishItems.Count > 0)
            {
                foreach (var item in perishItems)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No Perishable Items Found.");
            }
        }
    }

    public class NonPerishableItem
    {
        public List<Ex2_4> nonPerish = new List<Ex2_4>();
        public void add(Ex2_4 item)
        {
            nonPerish.Add(item);
        }
        public void ViewNonPerishableItems()
        {
            if (nonPerish.Count > 0)
            {
                foreach (var item in nonPerish)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No Non-Perishable Items Found.");
            }
        }
    }
}