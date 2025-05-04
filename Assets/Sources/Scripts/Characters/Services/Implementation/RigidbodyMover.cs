using Sources.Scripts.Characters.Services.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Services.Implementation
{
	public class RigidbodyMover : IMover
	{
		private readonly Rigidbody _rigidbody;

		public RigidbodyMover(Rigidbody rigidbody) =>
			_rigidbody = rigidbody;
		
		public void Move(float speed,  Vector3 direction)
		{
			Vector3 targetPosition = _rigidbody.position + direction * speed;
			_rigidbody.MovePosition(targetPosition);
		}

		public void Stop() =>
			_rigidbody.velocity = Vector3.zero;
	}
}