// See https://aka.ms/new-console-template for more information

using Level52;
using Level52.Utils;

ServiceLocator.UserInput = new ConsoleInput();
ServiceLocator.Display = new ConsoleDisplay();
ServiceLocator.Rng = new Random();

var game = new Game();
game.Run();