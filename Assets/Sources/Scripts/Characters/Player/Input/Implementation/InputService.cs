using System;
using Sources.Scripts.Characters.Player.Input.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Player.Input.Implementation
{
	public class InputService : IInputService
	{
		private const string Horizontal = "Horizontal";
		private const string Vertical = "Vertical";
		private const KeyCode SpaceCode = KeyCode.Space;
		private const string MouseYPosition = "Mouse Y";
		private const string MouseXPosition = "Mouse X";

		public event Action SpacePressed;
		public event Action MoveButtonPressed;
		public event Action AttackButtonPressed;
		
		public Vector2 Direction { get; private set; }

		public Vector2 MousePosition { get; private set;  }

		public void Update()
		{
			Direction = new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
			MousePosition = new Vector2(UnityEngine.Input.GetAxis(MouseXPosition), UnityEngine.Input.GetAxis(MouseYPosition));
			
			if (Direction != Vector2.zero)
				MoveButtonPressed?.Invoke();
			
			if (UnityEngine.Input.GetKeyDown(SpaceCode))
				SpacePressed?.Invoke();
			
			if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
				AttackButtonPressed?.Invoke();
		}
	}
}