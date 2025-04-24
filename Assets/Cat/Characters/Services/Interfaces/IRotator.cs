using UnityEngine;

namespace Cat.Characters.Services.Interfaces
{
	public interface IRotator
	{
		void RotateToDirection(Vector3 originPosition, Vector3 targetPosition);

		void RotateToMouse(float speed);

		void RotateToMoveDirection(Vector2 moveDirection, float speed);
	}
}