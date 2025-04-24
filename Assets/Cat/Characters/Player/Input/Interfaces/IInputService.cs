using System;
using UnityEngine;

namespace Cat.Characters.Player.Input.Interfaces
{
	public interface IInputService
	{
		event Action SpacePressed;

		Vector2 Direction { get; }

		void Update();

		event Action MoveButtonPressed;

		event Action AttackButtonPressed;
	}
}