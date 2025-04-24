using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Services.Implementation
{
	public class Jumper : IJumper
	{
		private readonly Rigidbody _rigidbody;

		public Jumper(Rigidbody rigidbody)
		{
			_rigidbody = rigidbody;
		}

		public Vector3 Velocity => _rigidbody.velocity;

		public void Jump(float force) =>
			_rigidbody.AddForce(Vector3.up * force);
	}
}