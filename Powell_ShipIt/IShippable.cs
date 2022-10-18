
namespace Powell_ShipIt
{
	internal interface IShippable
	{
		public decimal ShipCost { get; }
		public string  Product { get; }
	}
}
