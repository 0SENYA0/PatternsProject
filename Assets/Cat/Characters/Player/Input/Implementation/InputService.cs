using System;
using Cat.Characters.Player.Input.Interfaces;
using UnityEngine;

namespace Cat.Characters.Player.Input.Implementation
{
	public class InputService : IInputService
	{
		private const string Horizontal = "Horizontal";
		private const string Vertical = "Vertical";
		private const KeyCode SpaceCode = KeyCode.Space;

		public event Action SpacePressed;
		public event Action MoveButtonPressed;
		public event Action AttackButtonPressed;
		
		public Vector2 Direction { get; private set; }
		
		public void Update()
		{
			Direction = new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));

			if (Direction != Vector2.zero)
				MoveButtonPressed?.Invoke();
			
			if (UnityEngine.Input.GetKeyDown(SpaceCode))
				SpacePressed?.Invoke();
			
			if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
				AttackButtonPressed?.Invoke();
		}
	}
}