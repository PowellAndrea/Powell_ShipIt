
using System.Reflection.Metadata.Ecma335;

namespace Powell_ShipIt
{
	internal class Bicycle : IShippable
	{
		decimal IShippable.ShipCost => new decimal(20.5);
		string  IShippable.Product => "Bicycle";
	}
}