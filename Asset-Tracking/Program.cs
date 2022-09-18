/*
 *  Kod för att genera  Asset-Tracking listor
 *  Som sorteras med hjälp av LINQ
 * 
 * 
 * 
 * 
 */


//
//


// Create empty Lists
List<Computer> computerlist = new();
List<Phone> phonelist = new();



// ----------------- program start



// skapar input för antingen dator el. telefon

while (true)
{

    // Star() returnerar 1 el. 2 för antingen dator el. telefon
    int waschosen = Start();

    if (waschosen == 0)
    {
        ShowLists(computerlist, phonelist);
        break;
    }

    if (waschosen > 0 && waschosen < 3)
    {
        (string Ret, string model, DateTime dt, int price, string office) = ProductInput(waschosen);

        if (Ret == "comp")
        {
            computerlist.Add(new Computer(model, dt, price, office));
        }
        else if (Ret == "phone")
        {
            phonelist.Add(new Phone(model, dt, price, office));
        }
        else if (Ret == "ended")
        {
            ShowLists(computerlist, phonelist);
            break;
        }
    }

}


// ----------------- end program



// Methods

static int Start()
{

    string firstinput = "";
    bool Success = false;
    int category = 0;

    while (true)
    {

        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("Lägg till ny Dator(1) eller ny telefon(2).");
        Console.WriteLine("Avsluta med q för att visa olika listor över produkter.");
        Console.WriteLine("");
        Console.Write("Mata in 1 el. 2: ");

        try
        {
            firstinput = Console.ReadLine();

            if (firstinput.ToLower().Trim() == "q")
            {
                Console.WriteLine("Avslutar inmatning.");
                break;
            }

            Success = int.TryParse(firstinput, out category);

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felatig inmatning. Error: " + e);
            Console.WriteLine("Försök igen.");
            continue;
        }
        if (Success)
        {
            if (category > 0 && category < 3)   
            {
                break;
            }
            else
            {
                Console.WriteLine("Måste vara 1 eller 2. Försök igen");
                continue;
            }
        }
    }
    if (Success)
    {
        return category;
    }
    else
    {
        return 0;
    }

}




static (string, string, DateTime, int, string) ProductInput(int chosen)
{

    // Återanvänder kod från min Checkpoint-2.cs, men använder Try-Catch för viss error handling

    // declare empty strings
    string priceInput = "";
    string modelInput = "";
    string dateInput = "";
    string officeInput = "";

    DateTime truedate = DateTime.Now;
    int intPrice = 0;


    // reset color
    Console.ResetColor();
    Console.WriteLine("");
    if (chosen == 1)
    {
        Console.WriteLine("Lägg till ny Dator!");
    }
    else if (chosen == 2)
    {
        Console.WriteLine("Lägg till ny telefon!");
    }
    Console.WriteLine("Avsluta med q för att visa olika listor över produkterna.");
    Console.WriteLine("");


    // input modelname
    while (true)
    {

        try
        {
            Console.ResetColor();
            Console.Write("Skriv in din produkts modellnamn: ");
            modelInput = Console.ReadLine();

            if (modelInput.ToLower().Trim() == "q")
            {
                Console.WriteLine("Avslutar inmatning.");
                break;
            }

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
    
            Console.WriteLine("Felatig inmatning. Error: " + e);
            Console.WriteLine("Försök igen.");
            continue;

        }

        if (modelInput.Trim() == "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktig input! verkar vara tom. Försök igen.");
            continue;
        }
        else
        {
            break;
        }
    }
    if (modelInput.ToLower().Trim() == "q")
    {
        return ("ended", "none", DateTime.Now, 0, "");
    }



    // input Product purchase date
    while (true)
    {

        try
        {
            Console.ResetColor();
            Console.Write("Skriv in din produkts inköps datum(sähär 2022-06-06): ");
            dateInput = Console.ReadLine();

            if (dateInput.ToLower().Trim() == "q")
            {
                Console.WriteLine("Avslutar inmatning.");
                break;
            }

            truedate = DateTime.Parse(dateInput);

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felatig inmatning. Error: " + e);
            Console.WriteLine("Försök igen.");
            continue;

        }

        if (dateInput.Trim() == "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktig input! verkar vara tom. Försök igen.");
            continue;
        }
        else
        {
            break;
        }

    }
    if (dateInput.ToLower().Trim() == "q")
    {
        return ("ended", "none", DateTime.Now, 0, "");
    }



    // input Product Price
    while (true)
    {

        bool Success = false;

        try
        {
            Console.ResetColor();
            Console.Write("Skriv in din produkts pris i USD: ");
            priceInput = Console.ReadLine();

            if (priceInput.ToLower().Trim() == "q")
            {
                Console.WriteLine("Avslutar inmatning.");
                break;
            }

            Success = int.TryParse(priceInput, out intPrice);

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felatig inmatning. Error: " + e);
            Console.WriteLine("Försök igen.");
            continue;

        }

        if (Success == false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktigt pris värde! Försök igen.(endast siffror)");
            continue;
        }
        else
        {
            break;
        }

    }
    if (priceInput.ToLower().Trim() == "q")
    {
        return ("ended", "none", DateTime.Now, 0, "");
    }



    // input office
    string myOffice = "";
    while (true)
    {
        
        try
        {
            Console.ResetColor();
            Console.Write("Skriv in din produkts kontor: ");
            officeInput = Console.ReadLine();

            if (officeInput.ToLower().Trim() == "q")
            {
                Console.WriteLine("Avslutar inmatning.");
                break;
            }

        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Felatig inmatning. Error: " + e);
            Console.WriteLine("Försök igen.");
            continue;

        }

        if (officeInput.Trim() == "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktig input! verkar vara tom. Försök igen.");
            continue;
        }

        myOffice = officeInput.ToLower().Trim();
        if (myOffice == "usa" || myOffice == "spain" || myOffice == "sweden")
        {
            break;
        }       
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Felaktigt kontor! måste vara (USA, Spain , Sweden). Försök igen.");
            continue;
        }
    }
    if (modelInput.ToLower().Trim() == "q")
    {
        // , "Sydpolen" är ett skämt eftersom den returnerade variablen inte används vid fel eller avslut
        return ("ended", "none", DateTime.Now, 0, "Sydpolen");
    }

    // Return data for new entries in lists
    if (chosen == 1)
    {
        return ("comp", modelInput, truedate, intPrice, myOffice);
    }
    else if (chosen == 2)
    {
        return ("phone", modelInput, truedate, intPrice, myOffice);
    }
    else
    {
        return ("ended", "none", DateTime.Now, 0, "");
    }


}



static void ShowLists(List<Computer> computerRef, List<Phone> phoneRef)
{

    // reset color
    Console.ResetColor();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Alla Produkter sorterade efter Typ.");
    Console.WriteLine("");
    Console.WriteLine("Type".PadRight(15) + "Brand+Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(15) + "Price in USD".PadRight(15) + "Currency".PadRight(15) + "Local price today");

    // creating local lists from List references and sort the new lists
    List<Computer> sortedComputer = computerRef.OrderBy(m => m.ModelName).ToList();
    List<Phone> sortedPhone = phoneRef.OrderBy(m => m.ModelName).ToList();

    foreach (Computer obj in sortedComputer)
    {
        obj.ShowProduct();
    }

    foreach (Phone obj in sortedPhone)
    {
        obj.ShowProduct();
    }


    // Sort by Office

    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Alla Produkter sorterade efter Kontor.");
    Console.WriteLine("");
    Console.WriteLine("Type".PadRight(15) + "Brand+Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(15) + "Price in USD".PadRight(15) + "Currency".PadRight(15) + "Local price today");

    // concanate both Lists and order by Office
    var orderedResultOffice = sortedComputer.Concat<IProducts>(sortedPhone).OrderBy(q => q.Office);

    foreach (var obj in orderedResultOffice)
    {
        obj.ShowProduct();
    }
    

    // Sort by Purchase date

    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Alla Produkter sorterade efter inköps Datum.");
    Console.WriteLine("");
    Console.WriteLine("Type".PadRight(15) + "Brand+Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(15) + "Price in USD".PadRight(15) + "Currency".PadRight(15) + "Local price today");

    // concanate both Lists and orde by Purchase Date
    var orderedResult = sortedComputer.Concat<IProducts>(sortedPhone).OrderBy(q => q.PurchaseDate);

    DateTime now = DateTime.Now;
    DateTime months6away = now.AddMonths(-30);
    DateTime months3away = now.AddMonths(-33);
    DateTime threeyearsago = now.AddMonths(-36);

    foreach (var obj in orderedResult)
    {

        if (obj.PurchaseDate > threeyearsago) {
            if (obj.PurchaseDate < months3away)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                obj.ShowProduct();
                Console.ResetColor();
            }
            else if (obj.PurchaseDate < months6away)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                obj.ShowProduct();
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                obj.ShowProduct();
            }
        }
        Console.ResetColor();

    }


}



// CLASSES

interface IProducts
{
    public DateTime PurchaseDate { get; }

    public string Office { get; }

    void ShowProduct();

    // this is not used in full version
    void ShowOffice();

}


class Computer : IProducts
{
    public Computer(string modelName, DateTime purchaseDate, int price, string office)
    {
        ModelName = modelName;
        PurchaseDate = purchaseDate;
        Price = price;
        Office = office;
    }

    public string ModelName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int Price { get; set; }
    public string Office { set; get; }


    public void ShowProduct()
    {
        string currency = "";
        double localprice = 0.0;
        string MyOffice = "";

        if (Office == "sweden")
        {
            localprice = Price * 10.73;
            currency = "SEK";
            MyOffice = "Sweden";
        }
        else if (Office == "spain")
        {
            localprice = Price * 1;
            currency = "EUR";
            MyOffice = "Spain";
        }
        else if (Office == "usa")
        {
            localprice = Price;
            currency = "USD";
            MyOffice = "USA";
        }

        Console.WriteLine("Computer".PadRight(15) + ModelName.PadRight(15) + MyOffice.PadRight(15) + PurchaseDate.ToString("MM/dd/yyyy").PadRight(15) + Price.ToString().PadRight(15) + currency.PadRight(15) + localprice);

    }

    public void ShowOffice()
    {
        Console.Write(Office);
    }

}


class Phone : IProducts
{
    public Phone(string modelName, DateTime purchaseDate, int price, string office)
    {
        ModelName = modelName;
        PurchaseDate = purchaseDate;
        Price = price;
        Office = office;
    }

    public string ModelName { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int Price { get; set; }
    public string Office { set; get; }

    public void ShowProduct()
    {
        string currency = "";
        double localprice = 0.0;
        string MyOffice = "";

        if (Office == "sweden")
        {
            localprice = Price * 10.73;
            currency = "SEK";
            MyOffice = "Sweden";
        }
        else if (Office == "spain")
        {
            localprice = Price * 1;
            currency = "EUR";
            MyOffice = "Spain";
        }
        else if (Office == "usa")
        {
            localprice = Price;
            currency = "USD";
            MyOffice = "USA";
        }

        Console.WriteLine("Phone".PadRight(15) + ModelName.PadRight(15) + MyOffice.PadRight(15) + PurchaseDate.ToString("MM/dd/yyyy").PadRight(15) + Price.ToString().PadRight(15) + currency.PadRight(15) + localprice);

    }

    public void ShowOffice()
    {
        Console.Write("Office: " + Office);
    }

}



