bool continueRunning = true;

while (continueRunning)
{
    Console.WriteLine("Enter numbers to add:");
    string? input = Console.ReadLine();

    try
    {
        // Replace literal "\n" from user typing
        input = input?.Replace("\\n", "\n");

        input ??= string.Empty;

        var calculator = new StringCalculator.App.StringCalculator();
        int result = calculator.Add(input);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Result: {result}");
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {ex.Message}");
        Console.ResetColor();
    }

    // Prompt to continue or exit - this is a good practice for user experience
    Console.WriteLine("Do you want to try again? (Y/N):");
    string? response = Console.ReadLine()?.Trim().ToUpper();

    if (response != "Y")
    {
        continueRunning = false;
        Console.WriteLine("Exiting... Thank you!");
    }
}