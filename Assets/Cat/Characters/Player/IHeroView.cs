using Cat.Characters.Player.Settings;
using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Player
{
	public interface IHeroView
	{
		Transform transform { get; }

		IObstacleChecker ObstacleChecker { get; }
		IPlayerSetting PlayerSetting { get; }
	}
}