namespace Sources.Scripts.Characters.Player.Settings
{
	public interface IPlayerSetting
	{
		float RotateSpeed { get; }

		float MoveSpeed { get; }

		float JumpForce { get; }
	}
}