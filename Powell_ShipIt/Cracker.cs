

namespace Powell_ShipIt
{
	internal class Cracker : IShippable
	{
		decimal IShippable.ShipCost => new decimal(.57);
		string  IShippable.Product => "Cracker";
	}
}