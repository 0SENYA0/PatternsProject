using UnityEngine;

namespace Sources.Scripts.Characters.Services.Interfaces
{
	public interface IMover
	{
		void Move(float speed, Vector3 direction);

		void Stop();
	}
}