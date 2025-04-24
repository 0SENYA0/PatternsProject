using UnityEngine;

namespace Cat.Characters.Player.Settings
{
	[CreateAssetMenu(fileName = "PlayerSetting", menuName = "Cat/PlayerSetting")]
	public class PlayerSetting : ScriptableObject, IPlayerSetting
	{
		[field: SerializeField] public float RotateSpeed { get; private set; }
		[field: SerializeField] public float MoveSpeed { get; private set; }
		[field: SerializeField] public float JumpForce { get; private set; }
	}
}