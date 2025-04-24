using Cat.Characters.Services.Implementation;
using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Player
{
	public class CameraFollower : MonoBehaviour
	{
		private IThirdPersonCameraService _cameraService;

		public void Construct(Transform target)
		{
			_cameraService = new ThirdPersonCameraService(transform, target);
		}

		private void LateUpdate()
		{
			_cameraService.UpdateCamera(Time.deltaTime);
		}
	}
}