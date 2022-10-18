
using Powell_ShipIt;

bool Continue = true;

Shipper manafest = new();
Console.Clear();

LawnMower LawnMower = new();
Bicycle Bicycle = new();
BaseballGlove BaseballGlove = new();
Cracker Cracker = new();

while (Continue)
{
	Console.WriteLine("\n\n" +
		"Choose from the folllowing options:\n\n" +
		"1) Add a Bicycle to the shipment \n" +
		"2) Add a Lawn Mower to the Shipment\n" +
		"3) Add a Baseball Glove to the shipment\n" +
		"4) Add Crackers to the shipment\n" +
		"5) List Shipment Items\n" +
		"6) Compute Shipping Charges\n" +
		"7) Exit Program\n\n"
		);

	switch (Console.ReadLine())
	{
		case "1":
			manafest.Add(Bicycle);
			break;

		case "2":
			manafest.Add(LawnMower);
			break;

		case "3":
			manafest.Add(BaseballGlove);
			break;

		case "4":
			manafest.Add(Cracker);
			break;

		case "5":   //List Shipment Items
			manafest.ShowManafest();
			break;

		case "6":
			manafest.ShowManafest();
			manafest.CalculateCharges();
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
			Continue = false;
			break;

		default:
			Console.Clear();
			Console.WriteLine("End Program");
			Continue = false;
			break;
	}
}
