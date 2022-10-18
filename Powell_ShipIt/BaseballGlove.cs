
using System.Reflection.Metadata.Ecma335;

namespace Powell_ShipIt
{
	internal class BaseballGlove : IShippable
	{
		decimal IShippable.ShipCost => new decimal(3.23);
		string  IShippable.Product => "Baseball Glove";
	}
}