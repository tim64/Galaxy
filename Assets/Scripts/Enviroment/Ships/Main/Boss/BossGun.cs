public class BossGun : BaseShip
{
	/// <summary>
	/// Переопределенный метод старта
	/// </summary>
    public override void Start()
    {
		maxShootRate = 0.2f;
		useRandomShootRange = false;
		dmg = 10;
		shootForce = 15;

		base.Start();
	}
}
