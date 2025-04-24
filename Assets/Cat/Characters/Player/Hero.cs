using Cat.Characters.FSM.Interfaces;
using Cat.Characters.Player.Animations;
using Cat.Characters.Player.Input.Interfaces;
using Cat.Characters.Player.Settings;
using Cat.Characters.Services;
using Cat.Characters.Services.Implementation;
using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Player
{
	public class Hero : MonoBehaviour, IHeroView
	{
		[SerializeField] private HeroAnimator _heroAnimator;
		[SerializeField] private ObstacleChecker _obstacleChecker;
		[SerializeField] public PlayerSetting _playerSetting;

		[field: SerializeField] public Rigidbody Rigidbody { get; private set; }


		private IStateMachineUpdater _stateMachineUpdater;

		private IInputService _inputService;

		public IPlayerSetting PlayerSetting => _playerSetting;
		public IObstacleChecker ObstacleChecker => _obstacleChecker;
		public IHeroAnimator Animator => _heroAnimator;
		
		public void Construct(IStateMachineUpdater stateMachine, IInputService inputService)
		{
			_heroAnimator.Initialize();
			_inputService = inputService;
			_stateMachineUpdater = stateMachine;
		}

		private void Update()
		{
			_stateMachineUpdater.UpdateState(Time.deltaTime);
			_inputService.Update();
		}
		
		private void FixedUpdate() =>
			_stateMachineUpdater.FixedUpdateState(Time.fixedDeltaTime);
		
		private void LateUpdate() =>
			_stateMachineUpdater.LateUpdateState(Time.deltaTime);
	}
}