using Sources.Scripts.Characters.Player.Input.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Services.Implementation
{
	public class ThirdPersonCameraService
	{
		private readonly Transform _camera;
		private readonly Transform _target;
		private readonly IInputService _inputService;

		private float _distance = 5f;
		private float _height = 2f;
		private float _rotationSpeed = 120f;
		private float _mouseX;
		private float _mouseY;
		private float _minY = -40f;
		private float _maxY = 80f;

		public ThirdPersonCameraService(Transform camera, Transform target, IInputService inputService)
		{
			_camera = camera;
			_target = target;
			_inputService = inputService;
		}

		public void UpdateCamera(float deltaTime)
		{
			_mouseX += _inputService.MousePosition.x * _rotationSpeed * deltaTime; 
			_mouseY -= _inputService.MousePosition.y * _rotationSpeed * deltaTime;
			_mouseY = Mathf.Clamp(_mouseY, _minY, _maxY);

			Quaternion rotation = Quaternion.Euler(_mouseY, _mouseX, 0);
			Vector3 offset = rotation * new Vector3(0, 0, -_distance);
			Vector3 desiredPosition = _target.position + Vector3.up * _height + offset;

			_camera.position = desiredPosition;
			_camera.LookAt(_target.position + Vector3.up * _height);
		}
	}
}