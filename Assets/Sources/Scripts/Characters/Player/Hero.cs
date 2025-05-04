using Sources.Scripts.Characters.FSM.Interfaces;
using Sources.Scripts.Characters.Player.Animations;
using Sources.Scripts.Characters.Player.Input.Interfaces;
using Sources.Scripts.Characters.Player.Settings;
using Sources.Scripts.Characters.Services.Implementation;
using Sources.Scripts.Characters.Services.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Player
{
	public class Hero : MonoBehaviour, IHeroView
	{
		[SerializeField] private HeroAnimator _heroAnimator;
		[SerializeField] private ObstacleChecker _obstacleChecker;
		[SerializeField] private PlayerSetting _playerSetting;

		[field: SerializeField] public Rigidbody Rigidbody { get; private set; }


		private IStateMachineUpdater _stateMachineUpdater;

		private IInputService _inputService;

		public IPlayerSetting PlayerSetting => _playerSetting;
		public IObstacleChecker ObstacleChecker => _obstacleChecker;
		public IHeroAnimator Animator => _heroAnimator;
		
		public void Construct(IStateMachineUpdater stateMachine, IInputService inputService)
		{
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