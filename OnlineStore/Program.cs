namespace OnlineStore
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 1. När programmet körs så ska man få se någon form av meny där man ska kunna välja att registrera ny kund eller logga in
            //CHECK

            // 2. Därefter ska ytterligare en meny visas där man ska kunna välja att handla, se kundvagn eller gå till kassan
            //CHECK
            // 3. Om man väljer at thandla ska man få upp minst 3 olika produkter att köpa(t.ex.Korv,Dricka och Äpple).
            //   Man ska se pris för varje produkt och kunna lägga till vara i kundvagn.
            //CHECK
            // 4 Kundvagnen ska visa alla produkter man lagt i den,styck priset, antalet och total priset
            // samt totala kostnaden för hela kundvagnen
            //CHECK
            // 5. Kundvagnen skall sparas i kund och finnas tillgänglig när man loggar in
            //CHECK

            // 6. När man ska Registrera en ny kund ska man ange Namn och lösenord.
            // Dessa ska sparas och namnet ska inte gå att ändra
            //CHECK


            // 7. Väljer man Logga In så ska man skriva in namn och lösenord. Om användaren inte finns registrerad
            // ska programmet skriva ut att kunden inte finns och fråga ifall man vill registrera ny kund. 
            // Om lösenordet inte stämmer så ska programmet skriva ut att lösenordet är fel och låta användaren
            // försöka igen.
            //CHECK

            // 8. Både kund och produkt ska vara separata klasser med Properties för information och metoder
            // för att räkna ut total pris och verifiera lösenord.
            //CHECK

            // 9. I klassen Kund skall det finnasen ToString() som skriver ut Namn, lösenord och kundvagnen på ett snyggt sätt.
            //CHECK

            //Fix the currency converter to show properly in all menu options and when checking out. 

            //Add textfile to save customers. 

            bool programRunning = true;
            while (programRunning)
            {
                
                bool logginIn = true;
                Customer c = new Customer();
                while (logginIn)
                {
               

                    Console.WriteLine("Welcome, what would you like to do?");
                    Console.WriteLine("(1): Loggin");
                    Console.WriteLine("(2): Register");
                    int choice = StoreMechanics.ValueCheckInt("Enter Number: ");
                    if (choice == 1)
                    {
                        c = Customer.LogIn();
                        if(c != null)
                        {
                            logginIn = false;
                        }                    
                    }
                    else if (choice == 2)
                    {
                        c = Customer.RegisterCustumer();
                        logginIn = false;
                    //StoreMechanics.EnterShop(c);

                    }
                    else
                    {
                        Console.WriteLine("Try again");
                    }
                //
                }
                
                bool inStore = true;
                bool paid = false;
                while (inStore)
                {
                    Console.Clear();

                    int storeChoice = StoreMechanics.ValueCheckInt("What would you like to do? " +
                    "\n(1): Shop item " +
                    "\n(2): Show Shopping Cart Item Details " +
                    "\n(3): Check Out " +
                    "\n(4): Empty shoppingcart" +
                    "\n(5): Logout" +
                    "\n(6): Showcase customer info"+
                    "\n(7): Change Currency- US, EUR, SEK"+
                    "\n(8)Admin: see all cusomer info");

                    switch (storeChoice)
                    {
                        case 1:

                            StoreMechanics.ShowCaseInventory();
                            StoreMechanics.SelectToCart(c.Cart);

                            break;
                        case 2:

                            StoreMechanics.ShowcaseCart(c.Cart);
                            break;

                        case 3:

                            if (c.MemberType != "Regular")
                            {
                                Member m = Member.ConvertToMember(c, c.Cart);
                                double price = Member.GetFinalPrice(m.Cart);
                                double finalPrice = Product.PriceInCurrency(StoreMechanics.chosenCurrency, price);
                                paid = StoreMechanics.CheckedOut(price);
                                if (paid)
                                {
                                    c.Cart.Clear();
                                    logginIn = true;
                                    inStore = false;
                                    paid = false;
                                }
                            }
                            else
                            {
                                double finalPrice = StoreMechanics.ShowcaseCart(c.Cart);
                                paid = StoreMechanics.CheckedOut(finalPrice);
                                if (paid)
                                {
                                    c.Cart.Clear();
                                    logginIn = true;
                                    inStore = false;
                                    paid = false;
                                }
                            }
                            break;
                        case 4:
                            StoreMechanics.ResetCart(c.Cart);
                            break;
                        case 5:
                            c = null;
                            inStore = false;
                            logginIn = true;
                            break;
                        case 6:
                            Console.WriteLine(c.ToString());
                            
                            break;
                        case 7:
                            StoreMechanics.Changecurrency();
                            break;
                        case 8:
                            Customer.ListAllCustumers();
                            break;
                    }
                    StoreMechanics.PressEnterToContinue();
                }
            }




            
            
            Console.ReadKey();
        }
    }
}
