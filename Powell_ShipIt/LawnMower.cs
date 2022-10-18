
using System.Reflection.Metadata.Ecma335;

namespace Powell_ShipIt
{
	internal class LawnMower : IShippable
	{
		decimal IShippable.ShipCost => new decimal(24.0);
		string  IShippable.Product => "Lawn Mower"; 
	}
}