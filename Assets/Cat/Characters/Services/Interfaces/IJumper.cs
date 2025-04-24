using UnityEngine;

namespace Cat.Characters.Services.Interfaces
{
	public interface IJumper
	{
		void Jump(float force);

		Vector3 Velocity { get; }
	}
}