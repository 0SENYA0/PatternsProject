using UnityEngine;

namespace Sources.Scripts.Characters.Companions
{
	[CreateAssetMenu(fileName = "CompanionSetting", menuName = "ScriptableObject/CompanionSetting")]
	public class CompanionSetting : ScriptableObject, ICompanionSetting
	{
		[field: SerializeField] public float RotateSpeed { get; private set; }
		[field: SerializeField] public float MaxSpeed { get; private set; }
		[field: SerializeField] public float MinSpeed { get; private set; }
		[field: SerializeField] public float Acceleration { get; private set; }
		[field: SerializeField] public float DistanceToWalk { get; private set; }
		[field: SerializeField] public float DistanceToRun { get; private set; }
	}
}