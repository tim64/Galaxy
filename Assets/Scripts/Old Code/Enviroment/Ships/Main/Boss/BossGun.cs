using static Constants;

/// <summary>
/// Пушка босса.
/// </summary>
public class BossGun : BaseShip
{
	private void Awake()
    {
		shootRate = BOSS_GUN_SHOOT_RATE;
		useRandomShootRange = false;
		damage = BOSS_GUN_DAMAGE;
		shootForce = BOSS_GUN_FORCE;

		shootImmediately = true;	
		useRandomShootRange = false;
	}
}
