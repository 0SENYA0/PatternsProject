using Sources.Scripts.Characters.Services.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Services.Implementation
{
	public class Rotator : IRotator
	{
		public void RotateToDirection(Transform rotatable, Vector3 direction, float speed)
		{
			direction.y = 0f;
			direction.Normalize();
	
			Rotate(rotatable, direction, speed);
		}
		
		private void Rotate(Transform rotatable, Vector3 direction, float speed)
		{
			Quaternion targetRotation = Quaternion.LookRotation(direction);
			rotatable.rotation = Quaternion.Slerp(rotatable.rotation, targetRotation, speed);
		}
	}
}