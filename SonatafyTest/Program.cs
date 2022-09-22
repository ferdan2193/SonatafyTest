// See https://aka.ms/new-console-template for more information
using SonatafyTest;
using SonatafyTest.Helpers;
using SonatafyTest.Models;
using System.Drawing;


Console.WriteLine("MarsRovers System");

List<Rover> rovers = new List<Rover>();

#region Add exploration limit
ExplorationNorth:
Console.WriteLine("Enter limit exploration to (North East): Ex without parenteses (5 5), separate numbers by space ");
string explorationLimitInput = Console.ReadLine();
Point explorationLimitPoint = new Point();

if (!InputValidator.convertToExplorationPointLimit(explorationLimitInput, out explorationLimitPoint))
{
    Console.WriteLine("Exploration limit point were not typed correctly, please ensure to type integers separated by space only.");
    goto ExplorationNorth;
}
#endregion


#region Add Rover Details
RoverDetails:
Console.WriteLine();
Console.WriteLine("Please add rover details");



#region Add Initial Point to new Rover
InitialPoint:
InitialPoint initialPoint = new InitialPoint();
Console.WriteLine();
Console.WriteLine("Add Initial Point and direction: (X Y Z) Ex: 5 3 S");
string initialPointInput = Console.ReadLine();
if (!InputValidator.initialPointValidation(initialPointInput, out initialPoint))
{
    Console.WriteLine("Initial Point don't was typed in correct format. Please try again without parenteses and with spaces ex: (X Y Z)");
    Console.WriteLine("Do you want to try again? (Y/N)");
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    if (keyInfo.Key != ConsoleKey.N)
    {
        goto InitialPoint;
    }
    else
        goto ExecuteMarsRovers;
}
#endregion



#region Add Instructions to new rober
Instructions:
string instructions = string.Empty;
Console.WriteLine();
Console.WriteLine($"Add Instructions for ({initialPointInput}); allowed letters (L,M,R) another letters will be ignored");
string instructionsInput = Console.ReadLine();

if (!InputValidator.validateInstructions(instructionsInput.ToUpper(), out instructions))
{
    Console.WriteLine("Instructions typed does not contain any valid letter");
    Console.WriteLine($"Do you want to configure ({ initialPointInput }) rover? (Y/N)");
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.Y)
    {
        goto Instructions;
    }
    else
        goto ExecuteMarsRovers;
}
#endregion



//This code not be getting if instructions and initial point were not filled correctly because "goto" sentence
Rover rover = new Rover(initialPoint, instructions);
rovers.Add(rover);
Console.WriteLine("Rover has been added");

#endregion


Console.WriteLine("Do you want to add another rover? (Y/N)");
ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
if (consoleKeyInfo.Key == ConsoleKey.Y)
{
    goto RoverDetails;
}


ExecuteMarsRovers:
// If none rover was added correctly there is an option to add one or exit program.
if(rovers.Count == 0)
{
    Console.WriteLine();
    Console.WriteLine("There is none rover configured, do you want to configure one? (Y, N)");
    ConsoleKeyInfo cki = Console.ReadKey();
    if (cki.Key == ConsoleKey.Y)
    {
        goto RoverDetails;
    }
    else
    {
        Console.WriteLine("Application will be closed, press any key.");
        Console.ReadKey();
        Environment.Exit(0);
    }

}

MarsRovers marsRoversSystem = new MarsRovers(explorationLimitPoint, rovers);
List<string> instructionsExecuted = marsRoversSystem.ExecuteInstructions();
Console.WriteLine();
Console.WriteLine();
foreach (string executed in instructionsExecuted)
{
    Console.WriteLine(executed);
}




Console.ReadKey();


//string[] startPoint = AddStart