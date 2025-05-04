using Sources.Scripts.Characters.Player.Settings;
using Sources.Scripts.Characters.Services.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Player
{
	public interface IHeroView
	{
		Transform transform { get; }

		IObstacleChecker ObstacleChecker { get; }
		IPlayerSetting PlayerSetting { get; }
	}
}