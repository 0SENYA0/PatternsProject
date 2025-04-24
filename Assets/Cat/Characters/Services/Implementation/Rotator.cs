using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Services.Implementation
{
	public class Rotator : IRotator
	{
		private readonly Transform _character;
		private Vector3 _lastMousePosition;

		public Rotator(Transform character)
		{
			_character = character;
		}

		public void RotateToMouse(float speed)
		{
			if (Vector3.Distance(_lastMousePosition, Input.mousePosition) < 0.01f)
				return;

			Vector3 direction = (Input.mousePosition - _lastMousePosition).normalized;
			direction.y = 0f;

			_lastMousePosition = Input.mousePosition;

			Rotate(direction, speed);
		}
		
		public void RotateToMoveDirection(Vector2 moveDirection, float speed)
		{
			if (moveDirection.sqrMagnitude < 0.001f)
				return;

			Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y).normalized;

			Quaternion targetRotation = Quaternion.LookRotation(direction);
			_character.rotation = Quaternion.Slerp(_character.rotation, targetRotation, speed);
		}
		
		public void RotateToDirection(Vector3 originPosition, Vector3 targetPosition)
		{
			Vector3 direction = targetPosition - originPosition;
			direction.y = 0f;

			if (direction.sqrMagnitude > 0.001f)
				Rotate(direction, 1f);
		}

		private void Rotate(Vector3 direction, float speed)
		{
			Quaternion targetRotation = Quaternion.LookRotation(direction);
			_character.rotation = Quaternion.Slerp(_character.rotation, targetRotation, speed);
		}
	}
}