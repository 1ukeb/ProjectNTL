namespace NTL.Gameplay
{
    public class BurstShotPowerup : TimedPowerupSO
    {
        public int additionalShots;

        public override void ApplyPowerup(TankEntity tank)
        {
            tank.GetComponent<TankWeapon>().AddShootCounter(additionalShots);
        }

        public override void RemovePowerup(TankEntity tank)
        {
            tank.GetComponent<TankWeapon>().RemoveShootCounter(additionalShots);
        }
    }
}
