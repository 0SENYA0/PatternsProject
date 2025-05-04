using System;
using UnityEngine;

namespace Sources.Scripts.Characters.Player.Input.Interfaces
{
	public interface IInputService
	{
		event Action SpacePressed;

		Vector2 Direction { get; }

		Vector2 MousePosition { get; }

		void Update();

		event Action MoveButtonPressed;

		event Action AttackButtonPressed;
	}
}