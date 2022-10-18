// Does the Add function, reports, etc.

// REMEMBER THIS
// if (line._product.Product == product.Product){ };

using System.Security.Cryptography.X509Certificates;

namespace Powell_ShipIt
{
	public class Shipper
	{
		class LineItem
		{
			public IShippable _product;
			public int _quantity;

			public LineItem(IShippable Product)
			{
				_product = Product;
				_quantity = 0;
			}
		}

		List<LineItem> Manafest;

		public Shipper()
		{
			Manafest = new List<LineItem>();
		}

		internal bool Add(IShippable product)
		{
			int quantity = GetQuantity(product);
			return Add(product, quantity);
		}

		internal bool Add(IShippable product, int quantity)
		{
			LineItem newLine = new LineItem(product);
			newLine._quantity = quantity;
			newLine._product = product;
			Manafest.Add(newLine);

			Console.Write(Math.Abs(newLine._quantity)
				+ " " 
				+ newLine._product.Product);
			if (newLine._quantity !=1)
			{
				Console.WriteLine("s have been added.\n");
			}
			else
			{
				Console.WriteLine(" has been added.");
			}
			return true;
		}

		public void ShowManafest()
		{
			Console.Clear();
			Console.WriteLine("Shipment manafest:");

			var groupBy = from line in Manafest
							  group line by line._product.Product into newGroup
							  orderby newGroup.Key
							  select newGroup;

			foreach (var group in groupBy)
			{
				int count = 0;
				foreach (var thing in group)
				{
					count = count + thing._quantity;
				}
				Console.WriteLine(
					group.Key 
					+ "\t\t"
					+ count);

				//int itemCount = 0;
				//foreach (LineItem line in Manafest)
				//{
				//	if (line._product == item)
				//	{
				//		itemCount = itemCount + line._quantity;
				//	}
				//}
				//if (itemCount != 0)
				//{
				//	Console.WriteLine(itemCount + " " + item.Product + "s");
				//}
			}
		}


			//// this is a hack, but I am tired.
			//uniqueItems.Add(new Bicycle());
			//uniqueItems.Add(new LawnMower());
			//uniqueItems.Add(new BaseballGlove());
			//uniqueItems.Add(new Cracker());

			//foreach(IShippable item in uniqueItems)
			//{
			//	int itemCount = 0;
			//	foreach (LineItem line in Manafest)
			//	{
			//		if(line._product == item){
			//			itemCount = itemCount + line._quantity;
			//		}
			//	}
			//	if (itemCount != 0)
			//	{
			//		Console.WriteLine(itemCount + " " + item.Product + "s");
			//	}
			//}

		public void CalculateCharges()
		{
			ShowManafest();
			decimal ShippingCost = 0;
			foreach (LineItem Line in Manafest)
			{
				ShippingCost = ShippingCost + (Line._quantity * Line._product.ShipCost);
			}

			Console.WriteLine("Total Shipping Cost: \t"
				+ ShippingCost
				);
		}

		int GetQuantity(IShippable item)
		{
			int quantity = 0;

			Console.WriteLine("How many " + item.Product 
				+ "s would you like to add?"
				+ "  Enter a negative number to remove an item.");

			string answer = Console.ReadLine();
			try
			{
				quantity = Convert.ToInt32(answer);

			}
			catch (InvalidCastException e)
			{
				Console.WriteLine("Invalid entry.  Enter a numeric value. ");
				return 0;
			}
			return quantity;
		}
	}
}




