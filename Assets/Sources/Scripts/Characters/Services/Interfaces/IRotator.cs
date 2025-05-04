using UnityEngine;

namespace Sources.Scripts.Characters.Services.Interfaces
{
	public interface IRotator
	{
		void RotateToDirection(Transform rotatable, Vector3 direction, float speed);
	}
}