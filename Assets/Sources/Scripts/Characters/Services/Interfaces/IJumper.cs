using UnityEngine;

namespace Sources.Scripts.Characters.Services.Interfaces
{
	public interface IJumper
	{
		void Jump(float force);

		Vector3 Velocity { get; }
	}
}