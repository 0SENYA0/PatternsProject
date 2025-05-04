namespace Sources.Scripts.Characters.Companions
{
	public interface ICompanionSetting
	{
		float RotateSpeed { get; }
		float MaxSpeed { get; }
		float MinSpeed { get; }
		
		float Acceleration { get; }

		float DistanceToWalk { get; }

		float DistanceToRun { get; }
	}
}