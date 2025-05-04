using Sources.Scripts.Cameras;
using Sources.Scripts.Characters.Player.Input.Interfaces;
using Sources.Scripts.Characters.Services.Implementation;
using UnityEngine;

namespace Sources.Scripts.Characters.Player.States.Implementation
{
	public class CameraFollower : MonoBehaviour, ICameraView
	{
		private ThirdPersonCameraService _cameraService;

		public void Construct(Transform target, IInputService inputService)
		{
			_cameraService = new ThirdPersonCameraService(transform, target, inputService);
		}

		private void LateUpdate()
		{
			_cameraService.UpdateCamera(Time.deltaTime);
		}
	}
}