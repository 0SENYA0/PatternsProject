using UnityEngine;

namespace Cat.Characters.Services.Interfaces
{
	public interface IMover
	{
		void Move(float speed, Vector3 direction);

		Vector3 Velocity { get;  }
	}
}