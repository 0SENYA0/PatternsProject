using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Services.Implementation
{
	public class ThirdPersonCameraService : IThirdPersonCameraService
	{
		private readonly Transform _camera;
		private readonly Transform _target;
		
		private float _distance = 5f;
		private float _height = 2f;
		private float _rotationSpeed = 120f;
		private float _mouseX;
		private float _mouseY;
		private float _minY = -40f;
		private float _maxY = 80f;

		public ThirdPersonCameraService(Transform camera, Transform target)
		{
			_camera = camera;
			_target = target;
		}

		public void UpdateCamera(float deltaTime)
		{
			_mouseX += Input.GetAxis("Mouse X") * _rotationSpeed * deltaTime;
			_mouseY -= Input.GetAxis("Mouse Y") * _rotationSpeed * deltaTime;
			_mouseY = Mathf.Clamp(_mouseY, _minY, _maxY);

			Quaternion rotation = Quaternion.Euler(_mouseY, _mouseX, 0);
			Vector3 offset = rotation * new Vector3(0, 0, -_distance);
			Vector3 desiredPosition = _target.position + Vector3.up * _height + offset;

			_camera.position = desiredPosition;
			_camera.LookAt(_target.position + Vector3.up * _height);
		}
	}
}