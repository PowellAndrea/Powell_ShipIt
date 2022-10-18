// Does the Add function, reports, etc.

// REMEMBER THIS
// if (line._product.Product == product.Product){ };

using System.Net.Http.Headers;
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
			
			Console.WriteLine("Press any key to continue");
			Console.ReadKey();
			Console.Clear();
			return true;
		}

		public void ShowManafest()
		{
			Console.Clear();
			Console.WriteLine("Shipment manafest:");

			//List<IShippable> uniqueItems = new();
			//decimal itemCount;
			//var q = Manafest.Select(x => x._product.Product.Distinct());

			//foreach (IShippable uniqueItem in q)
			//{
			//	itemCount = 0;
			
			foreach (LineItem line in Manafest)
			//	{
			//		if (line._product == uniqueItem)
			//		{
			//			itemCount = itemCount + line._quantity;
			//		}
			//		Console.WriteLine(itemCount + line._product.Product);
				Console.WriteLine(line._product.Product);
			//}
			Console.WriteLine("exit manafest");
		}

		public void CalculateCharges()
		{
			ShowManafest();
			decimal ShippingCost = 0;
			foreach (LineItem Line in Manafest)
			{
				ShippingCost = ShippingCost + (Line._quantity * Line._product.ShipCost);
			}

			Console.WriteLine("Total Shipping: \t"
				+ ShippingCost.ToString(format:"C0")
				);
		}

		int GetQuantity(IShippable item)
		{
			int quantity = 0;

			Console.WriteLine("How many " + item.Product 
				+ " would you like to add?"
				+ " Enter a negative number to remove an item.");

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




