using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Services.Implementation
{
	public class TransformMover : IMover
	{
		private readonly Transform _transform;

		public TransformMover(Transform transform) =>
			_transform = transform;

		public void Move(float speed, Vector3 direction) =>
			_transform.position += direction * speed;

		public Vector3 Velocity { get; }
	}
}