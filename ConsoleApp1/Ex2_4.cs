using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    abstract public class Item
    {
        abstract public void add(Ex2_4 item);
        abstract public void remove(Ex2_4 item);
        abstract public void search(Ex2_4 item);
        abstract public void update(Ex2_4 item);

    }
    public class Ex2_4()
    {
        private String name;
        private String category;
        private String stock;
        private string ProductID;
        private int StockQuantity;
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
            return "Name : "+name+"\nCategory : "+category+"\nStock Quantity : "+StockQuantity+"\nProductID : "+ProductID;
        }
    }
    public class InventoryItems : Item
    {
        public List<Ex2_4> firstlist = new List<Ex2_4>();
        public string ProductID;
        public int StockQuantity;
        public override void add(Ex2_4 item)
        {
            Console.Write("Enter The Quantity of Product:");
            StockQuantity = int.Parse(Console.ReadLine());
            item.setStockQuantity(StockQuantity);
            item.setProductID(setProductId(item.getName(), item.getCategory()));
            firstlist.Add(item);
            Console.WriteLine("Product has added successfully!");
        }
        public static string setProductId(string name, string category)
        {
            return name + "_" + category + " my product!";
        }
        public void viewProducts()
        {
            if (firstlist.Count > 0)
            {
                Console.WriteLine("\nList of Products!\n");
                for (int i = 0; i < firstlist.Count; i++)
                {
                    Console.WriteLine(firstlist[i]);
                }
            }
            else
            {
                Console.WriteLine("No Products Bhaiya!");
            }
        }
        public void viewProductsName()
        {
            if (firstlist.Count > 0)
            {
                Console.WriteLine("\nList of Products!\n");
                for (int i = 0; i < firstlist.Count; i++)
                {
                    Console.WriteLine(firstlist[i].getName());
                }
            }
            else
            {
                Console.WriteLine("No Products Bhaiya!");
            }
        }
        public override void remove(Ex2_4 item)
        {
            String name = Console.ReadLine();
            bool flag = false;
            for (int i = 0; i < firstlist.Count; i++)
            {
                if (firstlist[i].getName().Equals(name))
                {
                    firstlist.RemoveAt(i);
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Product not found!");
            }
        }
        public override void search(Ex2_4 item)
        {
            String name = Console.ReadLine();
            bool flag = false;
            int quantity = 0;
            for (int i = 0; i < firstlist.Count; i++)
            {
                if (firstlist[i].getName().Equals(name))
                {
                    flag = true;
                    quantity = firstlist[i].getStockQuantity();
                }
            }
            if (!flag)
            {
                Console.WriteLine("Product not found!");
            }
            else
            {
                Console.WriteLine("Product Exists & It's Quantity is " + quantity);
            }
        }
        public override void update(Ex2_4 item)
        {
            String name = Console.ReadLine();
            bool flag = false;
            for (int i = 0; i < firstlist.Count; i++)
            {
                if (firstlist[i].getName().Equals(name))
                {
                    flag = true;
                    int opt = int.Parse(Console.ReadLine());
                    Console.Write("1.Update Product Name\n2.Update the Quanity\n3.Update the Category\n\nEnter a valid option:");
                    if (opt == 1)
                    {
                        Console.WriteLine("Enter the New Product Name : ");
                        Console.WriteLine("Old Product Name :" + firstlist[i].getName());
                        Console.Write("New Product Name :");
                        firstlist[i].setName(Console.ReadLine());
                    }
                    else if (opt == 2)
                    {
                        Console.WriteLine("Enter the New Product Quanity : ");
                        Console.WriteLine("Old Product Quanity :" + firstlist[i].getStockQuantity());
                        Console.Write("New Product Quantity :");
                        firstlist[i].setStockQuantity(int.Parse(Console.ReadLine()));
                    }
                    else if (opt == 3)
                    {
                        Console.WriteLine("Enter the New Product Category : ");
                        Console.WriteLine("Old Product Quanity :" + firstlist[i].getCategory());
                        Console.Write("New Product Category :");
                        firstlist[i].setCategory(Console.ReadLine()); 
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option!");
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine("Product not found!");
            }
            else
            {
                Console.WriteLine("Product Updated Successfully");
            }
        }
    }
}