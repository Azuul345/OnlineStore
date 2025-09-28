namespace OnlineStore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. När programmet körs så ska man få se någon form av meny där man ska kunna välja att registrera ny kund eller logga in

            // 2. Därefter ska ytterligare en meny visas där man ska kunna välja att handla, se kundvagn eller gå till kassan

            // 3. Om man väljer at thandla ska man få upp minst 3 olika produkter att köpa(t.ex.Korv,Dricka och Äpple).
            //   Man ska se pris för varje produkt och kunna lägga till vara i kundvagn.

            // 4 Kundvagnen ska visa alla produkter man lagt i den,styck priset, antalet och total priset
            // samt totala kostnaden för hela kundvagnen

            // 5. Kundvagnen skall sparas i kund och finnas tillgänglig när man loggar in

            // 6. När man ska Registrera en ny kund ska man ange Namn och lösenord.
            // Dessa ska sparas och namnet ska inte gå att ändra

            // 7. Väljer man Logga In så ska man skriva in namn och lösenord. Om användaren inte finns registrerad
            // ska programmet skriva ut att kunden inte finns och fråga ifall man vill registrera ny kund. 
            // Om lösenordet inte stämmer så ska programmet skriva ut att lösenordet är fel och låta användaren
            // försöka igen.

            // 8. Både kund och produkt ska vara separata klasser med Properties för information och metoder
            // för att räkna ut total pris och verifiera lösenord.

            // 9. I klassen Kund skall det finnasen ToString() som skriver ut Namn, lösenord och kundvagnen på ett snyggt sätt.




            while (true)
            {

                Console.WriteLine("Welcome, what would you like to do?");
                Console.WriteLine("(1): Loggin");
                Console.WriteLine("(2): Register");
                int choice = StoreMechanics.ValueCheckInt("Enter Number: ");
                if (choice == 1)
                {                   
                    Customer.LogIn();
                }
                else if (choice == 2)
                {
                    Customer c = Customer.RegisterCustumer();
                    StoreMechanics.EnterShop(c);
                }
                else
                {
                    Console.WriteLine("Try again");
                }

            }

            //Console.WriteLine("Welcome, what would you like to do?");
            //Console.WriteLine("(1): Loggin");
            //Console.WriteLine("(2): Register");
            //int choice = StoreMechanics.ValueCheckInt("Enter Number: ");
            //if (choice == 1)
            //{
            //    //login

            //    //StoreMechanics.EnterShop(HERE);
            //}
            //else if (choice == 2)
            //{
            //    Customer c = Customer.RegisterCustumer();
            //    StoreMechanics.EnterShop(c);
            //}
            //else
            //{
            //    Console.WriteLine("Try again");
            //}

                //StoreMechanics.LogInOrRegister();



            //List<Product> ShoppingCart = new List<Product>();
            //bool inStore = true;

            //while (inStore)
            //{
            //    Console.Clear();

            //    int storeChoice = StoreMechanics.ValueCheckInt("What would you like to do? " +
            //        "\n(1): Shop item " +
            //        "\n(2): Show Shopping Cart Item Details ");

            //    switch (storeChoice)
            //    {
            //        case 1:

            //            StoreMechanics.ShowCaseInventory();
            //            StoreMechanics.SelectToCart(ShoppingCart);
                        
            //            break;
            //        case 2:
                        
            //            StoreMechanics.ShowCaseCart(ShoppingCart);
            //            break;

            //        case 3:
            //            break;


            //    }
            //    Console.ReadKey();
                
            //        //StoreMechanics.AddItem(ShoppingCart);

            //}


            //if (login)


            //else (register






                Console.ReadKey();
        }
    }
}
