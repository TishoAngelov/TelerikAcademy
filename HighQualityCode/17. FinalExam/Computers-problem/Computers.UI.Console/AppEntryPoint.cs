namespace Computers.UI.Console
{
    using System;
    using Computers.UI.Console.AbstractFactory;
    using Computers.UI.Console.Interfaces;

    public class AppEntryPoint
    {
        public static void Main()
        {
            IPlayableComputer pc;
            IChargeableComputer laptop;
            IProcessableComputer server;

            var manufacturerAsString = Console.ReadLine();

            ComputerManufacturer manufacturer;
            if (manufacturerAsString == "HP")
            {
                manufacturer = new HPComputers();
            }
            else if (manufacturerAsString == "Dell")
            {
                manufacturer = new DellComputers();                
            }
            else if (manufacturerAsString == "Lenovo")
            {
                manufacturer = new LenovoComputers();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            pc = manufacturer.ManufacturePC();
            server = manufacturer.ManufactureServer();
            laptop = manufacturer.ManufactureLaptop();

            while (true)
            {
                string userCommand = Console.ReadLine();
                if (userCommand == null)
                {
                    throw new NullReferenceException("The command cannot be null.");
                }

                if (userCommand.StartsWith("Exit"))
                {
                    Environment.Exit(0);
                }

                var splitedUserCommand = userCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitedUserCommand.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = splitedUserCommand[0];
                var commandArguments = int.Parse(splitedUserCommand[1]);

                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArguments);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArguments);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandArguments);
                }
            }
        }
    }
}
