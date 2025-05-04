using Sources.Scripts.Characters.FSM.Interfaces;
using Sources.Scripts.Characters.FSM.Interfaces.States;
using Sources.Scripts.Characters.FSM.Interfaces.States.UpdatableStates;
using Sources.Scripts.Characters.Player.Animations;
using Sources.Scripts.Characters.Player.Input.Interfaces;
using Sources.Scripts.Characters.Services.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Player.States.Implementation
{
	public class HeroIdleState : IExitableState, IEnterableState, IUpdatableState
	{
		private const float Epsilon = 0.01f;

		private readonly IInputService _inputService;
		private readonly IHeroAnimator _heroAnimator;
		private readonly IObstacleChecker _obstacleChecker;

		private IStateChanger _stateChanger;

		public HeroIdleState(IInputService inputService, IHeroAnimator heroAnimator, IObstacleChecker obstacleChecker)
		{
			_inputService = inputService;
			_heroAnimator = heroAnimator;
			_obstacleChecker = obstacleChecker;
		}

		public void SetStateChanger(IStateChanger stateChanger)
		{
			_stateChanger = stateChanger;
		}

		public void Enter()
		{
			_heroAnimator.PlayIdle();

			_inputService.SpacePressed += ChangeToJumpState;
		}

		public void Exit()
		{
			_inputService.SpacePressed -= ChangeToJumpState;
		}

		public void Update(float deltaTime)
		{
			if (Vector2.SqrMagnitude(_inputService.Direction) > Epsilon)
				_stateChanger.ChangeState<HeroMoveState>();
		}
		
		private void ChangeToJumpState()
		{
			if (_obstacleChecker.IsCollided)
				_stateChanger.ChangeState<HeroJumpState>();
		}
	}
}