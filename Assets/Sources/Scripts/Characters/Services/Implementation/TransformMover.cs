using Sources.Scripts.Characters.Services.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Services.Implementation
{
	public class TransformMover : IMover
	{
		private readonly Transform _transform;

		public TransformMover(Transform transform) =>
			_transform = transform;

		public void Move(float speed, Vector3 direction) =>
			_transform.position += direction * speed;

		public void Stop()
		{
		}
	}
}