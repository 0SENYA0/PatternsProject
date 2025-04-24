using Cat.Characters.FSM.Interfaces;
using Cat.Characters.FSM.Interfaces.States;
using Cat.Characters.FSM.Interfaces.States.UpdatableStates;
using Cat.Characters.Player.Animations;
using Cat.Characters.Player.Input.Interfaces;
using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Player.States.Implementation
{
	public class HeroIdleState : IExitableState, IEnterableState, IUpdatableState
	{
		private const float Epsilon = 0.01f;

		private readonly IInputService _inputService;
		private readonly IHeroAnimator _heroAnimator;
		private readonly IObstacleChecker _obstacleChecker;
		private readonly IRotator _rotator;
		private readonly IHeroView _heroView;

		private IStateChanger _stateChanger;

		public HeroIdleState(IInputService inputService, IHeroAnimator heroAnimator, IObstacleChecker obstacleChecker, IRotator rotator, IHeroView heroView)
		{
			_inputService = inputService;
			_heroAnimator = heroAnimator;
			_obstacleChecker = obstacleChecker;
			_rotator = rotator;
			_heroView = heroView;
		}

		public void SetStateChanger(IStateChanger stateChanger)
		{
			_stateChanger = stateChanger;
		}

		public void Enter()
		{
			_heroAnimator.PlayIdle();

			_inputService.SpacePressed += ChangeToJumpState;
			_inputService.AttackButtonPressed += ChangeToAttackState;
		}

		public void Exit()
		{
			_inputService.SpacePressed -= ChangeToJumpState;
			_inputService.AttackButtonPressed -= ChangeToAttackState;
		}

		public void Update(float deltaTime)
		{
			_rotator.RotateToMouse(_heroView.PlayerSetting.RotateSpeed * deltaTime);
			
			if (Vector2.SqrMagnitude(_inputService.Direction) > Epsilon)
				_stateChanger.ChangeState<HeroMoveState>();
		}

		private void ChangeToAttackState()
		{
			//_stateChanger.ChangeState<AttackState>(); TODO будет реализовано
		}

		private void ChangeToJumpState()
		{
			if (_obstacleChecker.IsCollided)
				_stateChanger.ChangeState<HeroJumpState>();
		}
	}
}