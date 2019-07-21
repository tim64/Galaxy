using static Constants;

public class BossGun : BaseShip
{
	/// <summary>
	/// Переопределенный метод старта
	/// </summary>
    public override void Start()
    {
		shootRate = BOSS_GUN_SHOOT_RATE;
		useRandomShootRange = false;
		damage = BOSS_GUN_DAMAGE;
		shootForce = BOSS_GUN_FORCE;

		base.Start();
	}
}
