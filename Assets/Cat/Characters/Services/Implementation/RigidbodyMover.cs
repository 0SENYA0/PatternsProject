using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Services.Implementation
{
	public class RigidbodyMover : IMover
	{
		private readonly Rigidbody _rigidbody;

		public RigidbodyMover(Rigidbody rigidbody) =>
			_rigidbody = rigidbody;
		
		public Vector3 Velocity => _rigidbody.velocity;

		public void Move(float speed,  Vector3 direction) =>
			_rigidbody.velocity = new Vector3(direction.x, 0, direction.y) * (speed);
	}
}