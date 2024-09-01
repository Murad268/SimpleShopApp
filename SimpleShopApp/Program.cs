using System;
using System.Collections;
using System.Text;


     ArrayList productCategories = new ArrayList()
    {
        new Hashtable()
        {
            {"id", 1},
            {"name", "Phone"}
        },
        new Hashtable()
        {
            {"id", 2},
            {"name", "Notebook"}
        }
    };

     ArrayList products = new ArrayList()
    {
        new Hashtable()
        {
            {"id", 1},
            {"name", "Apple iPhone 15 Pro"},
            {"model", "iPhone 15 Pro"},
            {"price", 1199.99},
            {"quantity", 10},
            {"product_category_id", 1}
        },
        new Hashtable()
        {
            {"id", 2},
            {"name", "Samsung Galaxy S23 Ultra"},
            {"model", "Galaxy S23 Ultra"},
            {"price", 1199.99},
            {"quantity", 8},
            {"product_category_id", 1}
        },
        new Hashtable()
        {
            {"id", 3},
            {"name", "Google Pixel 7 Pro"},
            {"model", "Pixel 7 Pro"},
            {"price", 899.99},
            {"quantity", 15},
            {"product_category_id", 1}
        },
        new Hashtable()
        {
            {"id", 4},
            {"name", "OnePlus 11"},
            {"model", "OnePlus 11"},
            {"price", 699.99},
            {"quantity", 12},
            {"product_category_id", 1}
        },
        new Hashtable()
        {
            {"id", 5},
            {"name", "Dell XPS 13"},
            {"model", "XPS 13"},
            {"price", 1299.99},
            {"quantity", 7},
            {"product_category_id", 2}
        },
        new Hashtable()
        {
            {"id", 6},
            {"name", "MacBook Air M2"},
            {"model", "MacBook Air M2"},
            {"price", 999.99},
            {"quantity", 5},
            {"product_category_id", 2}
        },
        new Hashtable()
        {
            {"id", 7},
            {"name", "HP Spectre x360"},
            {"model", "Spectre x360"},
            {"price", 1149.99},
            {"quantity", 6},
            {"product_category_id", 2}
        },
        new Hashtable()
        {
            {"id", 8},
            {"name", "Lenovo ThinkPad X1 Carbon"},
            {"model", "X1 Carbon"},
            {"price", 1399.99},
            {"quantity", 4},
            {"product_category_id", 2}
        }
    };


        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

    Start:
        Console.WriteLine("1: Show all products, 2: Show products by category, 3: Show total company price, 4: Show total price for category, 5: Add product, 6: Sell product");

        var selectedVariant = Console.ReadLine();
        int count = 0;

        if (selectedVariant == "1")
        {
            foreach (Hashtable product in products)
            {
                count++;
                Console.WriteLine($"number: {count}");
                Console.WriteLine($"name: {(string)product["name"]}");
                Console.WriteLine($"model: {(string)product["model"]}");
                Console.WriteLine($"price: {(double)product["price"]}");
                Console.WriteLine($"quantity: {(int)product["quantity"]}");
                Console.WriteLine($"category: {getCategory((int)product["product_category_id"])}");
                Console.WriteLine("==================");
            }
        }
        else if (selectedVariant == "2")
        {
            Console.WriteLine("Select category id");
            foreach (Hashtable category in productCategories)
            {
                Console.WriteLine($"{(int)category["id"]}: {(string)category["name"]}");
            }
            int selectedCategory = Convert.ToInt32(Console.ReadLine());
            getProductsByCategory(selectedCategory);
        }
        else if (selectedVariant == "3")
        {
            double price = 0;
            foreach (Hashtable product in products)
            {
                price += (double)product["price"];
            }
            Console.WriteLine($"Total company price: {price}");
        }
        else if (selectedVariant == "4")
        {
            Console.WriteLine("Select category id");
            foreach (Hashtable category in productCategories)
            {
                Console.WriteLine($"{(int)category["id"]}: {(string)category["name"]}");
            }
            int selectedCategory = Convert.ToInt32(Console.ReadLine());
            getProductsByCategory(selectedCategory, true, getCategory(selectedCategory));
        }
        else if (selectedVariant == "5")
        {
            addProduct();
        }
        else if (selectedVariant == "6")
        {
            foreach (Hashtable product in products)
            {
                count++;
                Console.WriteLine($"id: {(int)product["id"]}");
                Console.WriteLine($"name: {(string)product["name"]}");
                Console.WriteLine($"model: {(string)product["model"]}");
                Console.WriteLine($"price: {(double)product["price"]}");
                Console.WriteLine($"quantity: {(int)product["quantity"]}");
                Console.WriteLine($"category: {getCategory((int)product["product_category_id"])}");
                Console.WriteLine("==================");
            }
            sellProduct();
        } else
            {
                Console.WriteLine("Invalid selected variant");
            }

        goto Start;

     string getCategory(int product_category_id)
    {
        foreach (Hashtable category in productCategories)
        {
            if (category.ContainsKey("id") && (int)category["id"] == product_category_id)
            {
                return (string)category["name"];
            }
        }
        return "not found";
    }

     void getProductsByCategory(int product_category_id, bool getTotal = false, string category = null)
    {
        ArrayList willReturnedArray = new ArrayList();

        foreach (Hashtable product in products)
        {
            if (product.ContainsKey("product_category_id") &&
                (int)product["product_category_id"] == product_category_id)
            {
                willReturnedArray.Add(product);
            }
        }

        if (getTotal == false)
        {
            if (willReturnedArray.Count == 0)
            {
                Console.WriteLine("Products not found");
            }
            else
            {
                int count = 0;
                foreach (Hashtable product in willReturnedArray)
                {
                    count++;
                    Console.WriteLine($"number: {count}");
                    Console.WriteLine($"name: {(string)product["name"]}");
                    Console.WriteLine($"model: {(string)product["model"]}");
                    Console.WriteLine($"price: {(double)product["price"]}");
                    Console.WriteLine($"quantity: {(int)product["quantity"]}");
                    Console.WriteLine($"category: {getCategory((int)product["product_category_id"])}");
                    Console.WriteLine("==================");
                }
            }
        }
        else
        {
            double total = 0;
            foreach (Hashtable product in willReturnedArray)
            {
                total += (double)product["price"];
            }
            Console.WriteLine($"Total price for {category}: {total}");
        }
    }

     void addProduct()
    {
        Console.WriteLine("Enter product name:");
        string name;
        while (true)
        {
            name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                break;
            }
            Console.WriteLine("Product name cannot be empty. Please enter a valid name.");
        }

        Console.WriteLine("Enter product model:");
        string model;
        while (true)
        {
            model = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(model))
            {
                break;
            }
            Console.WriteLine("Product model cannot be empty. Please enter a valid model.");
        }

        double price;
        while (true)
        {
            Console.WriteLine("Enter product price:");
            string inputPrice = Console.ReadLine();
            int checkPrice;
            if (double.TryParse(inputPrice, out price) && price >= 0)
            {
               
                break;
            }
            
            Console.WriteLine("Invalid input. Please enter a valid price.");

            
        }
   

           
            int quantity;
        while (true)
        {
            Console.WriteLine("Enter product quantity:");
            string inputQuantity = Console.ReadLine();
            if (int.TryParse(inputQuantity, out quantity) && quantity >= 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid quantity.");
        }

        int categoryId;
        while (true)
        {
            Console.WriteLine("Enter product category id:");
            string inputCategoryId = Console.ReadLine();
            if (int.TryParse(inputCategoryId, out categoryId))
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid category id.");
        }

        Hashtable newProduct = new Hashtable
        {
            {"id", Guid.NewGuid()},
            {"name", name},
            {"model", model},
            {"price", price},
            {"quantity", quantity},
            {"product_category_id", categoryId}
        };

        products.Add(newProduct);
        Console.WriteLine("Product added successfully.");
    }

     void sellProduct()
    {
        Console.WriteLine("Enter product id to sell:");
        int idToSell;
        while (true)
        {
            string inputId = Console.ReadLine();
            if (int.TryParse(inputId, out idToSell))
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid product id.");
        }

        foreach (Hashtable product in products)
        {
            if ((int)product["id"] == idToSell)
            {
                int currentQuantity = (int)product["quantity"];
                Console.WriteLine($"Selling product: {(string)product["name"]}");

                int quantityToSell;
                while (true)
                {
                    Console.WriteLine("Enter quantity to sell:");
                    string inputQuantity = Console.ReadLine();
                    if (int.TryParse(inputQuantity, out quantityToSell) && quantityToSell > 0)
                    {
                        if (quantityToSell <= currentQuantity)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Quantity to sell cannot be more than available quantity.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid quantity.");
                    }
                }

                currentQuantity -= quantityToSell;
                product["quantity"] = currentQuantity;
                Console.WriteLine($"New quantity: {currentQuantity}");

                if (currentQuantity == 0)
                {
                    products.Remove(product);
                    Console.WriteLine("Product sold out and removed from inventory.");
                }
                return;
            }
        }
        Console.WriteLine("Product not found.");
    }

