using System;

class Program
{
    static void Main()
    {
        // Esta variable controla si el menú debe seguir apareciendo.
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("Enter a number to choose an option:");
            Console.WriteLine("1. Ticket price");
            Console.WriteLine("2. Group ticket price");
            Console.WriteLine("3. Repeat text ten times");
            Console.WriteLine("4. Show the third word");
            Console.WriteLine("0. Exit");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    keepRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;

                case "1":
                    ShowTicketPrice();
                    break;

                case "2":
                    ShowGroupPrice();
                    break;

                case "3":
                    RepeatText();
                    break;

                case "4":
                    ShowThirdWord();
                    break;

                case null:
                    // Termina si ya no hay entrada disponible para leer.
                    keepRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            // Añade una línea vacía para separar los mensajes del menú.
            Console.WriteLine();
        }
    }

    static void ShowTicketPrice()
    {
        Console.WriteLine("Enter your age:");
        string? input = Console.ReadLine();

        // Intenta obtener una edad entera a partir del texto recibido.
        bool isValidAge = int.TryParse(input, out int age);

        // Si la conversión falla o la edad es negativa, vuelve al menú.
        if (!isValidAge || age < 0)
        {
            Console.WriteLine("Please enter a whole number of 0 or more.");
            return;
        }

        int price = CalculateTicketPrice(age);

        if (age < 20)
        {
            Console.WriteLine("Youth price: " + price + " kr");
        }
        else
        {
            if (age > 64)
            {
                Console.WriteLine("Senior price: " + price + " kr");
            }
            else
            {
                Console.WriteLine("Standard price: " + price + " kr");
            }
        }
    }

    static int CalculateTicketPrice(int age)
    {
        // Este método entrega el precio según la edad.
        // Se utiliza tanto para una persona como para un grupo.
        if (age < 20)
        {
            return 80;
        }
        else
        {
            if (age > 64)
            {
                return 90;
            }
            else
            {
                return 120;
            }
        }
    }

    static void ShowGroupPrice()
    {
        Console.WriteLine("How many people are going?");
        string? input = Console.ReadLine();

        bool isValidNumber = int.TryParse(input, out int numberOfPeople);

        // La cantidad debe ser un entero mayor que cero.
        if (!isValidNumber || numberOfPeople <= 0)
        {
            Console.WriteLine("Please enter a whole number greater than 0.");
            return;
        }

        // El total empieza en cero porque todavía no hemos sumado entradas.
        long totalPrice = 0;

        // Pregunta una edad por cada persona del grupo.
        for (int person = 0; person < numberOfPeople; person++)
        {
            Console.WriteLine("Enter the age of person " + (person + 1) + ":");
            string? ageInput = Console.ReadLine();

            bool isValidAge = int.TryParse(ageInput, out int age);

            // Cancela el cálculo si alguna edad es incorrecta.
            if (!isValidAge || age < 0)
            {
                Console.WriteLine("Invalid age. Group calculation cancelled.");
                return;
            }

            int ticketPrice = CalculateTicketPrice(age);

            // Añade el precio de esta entrada al total acumulado.
            totalPrice += ticketPrice;
        }

        Console.WriteLine("Number of people: " + numberOfPeople);
        Console.WriteLine("Total price: " + totalPrice + " kr");
    }

    static void RepeatText()
    {
        Console.WriteLine("Enter a text:");
        string? text = Console.ReadLine();

        // Comprueba si falta el texto, está vacío o solo contiene espacios.
        if (string.IsNullOrWhiteSpace(text))
        {
            Console.WriteLine("Please enter a text.");
            return;
        }

        // Repite el texto diez veces en la misma línea.
        for (int repetition = 1; repetition <= 10; repetition++)
        {
            Console.Write(repetition + ". " + text);

            // Añade una coma entre repeticiones, pero no después de la última.
            if (repetition < 10)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
    }

    static void ShowThirdWord()
    {
        Console.WriteLine("Enter a sentence with at least three words:");
        string? sentence = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(sentence))
        {
            Console.WriteLine("Please enter a sentence.");
            return;
        }

        // Separa la frase en cada espacio.
        // Los espacios consecutivos no generan elementos vacíos.
        var words = sentence.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        // Comprueba que exista una tercera palabra antes de buscarla.
        if (words.Length < 3)
        {
            Console.WriteLine("Please enter at least three words.");
            return;
        }

        // Las posiciones empiezan en 0: la tercera palabra está en la posición 2.
        Console.WriteLine("The third word is: " + words[2]);
    }
}