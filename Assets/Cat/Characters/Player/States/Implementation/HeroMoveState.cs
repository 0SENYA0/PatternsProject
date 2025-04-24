using Cat.Characters.FSM.Interfaces;
using Cat.Characters.FSM.Interfaces.States;
using Cat.Characters.FSM.Interfaces.States.UpdatableStates;
using Cat.Characters.Player.Animations;
using Cat.Characters.Player.Input.Interfaces;
using Cat.Characters.Services;
using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Player.States.Implementation
{
	public class HeroMoveState : IExitableState, IEnterableState, IUpdatableState, IFixableState
	{
		private const float Epsilon = 0.01f;
		
		private readonly IInputService _inputService;
		private readonly IHeroAnimator _heroAnimator;
		private readonly IMover _mover;
		private readonly IRotator _rotator;
		private readonly IHeroView _heroView;
		private IStateChanger _stateChanger;

		public HeroMoveState(IInputService inputService, IHeroAnimator heroAnimator, IMover mover, IRotator rotator, IHeroView heroView)
		{
			_inputService = inputService;
			_heroAnimator = heroAnimator;
			_mover = mover;
			_rotator = rotator;
			_heroView = heroView;
		}

		public void SetStateChanger(IStateChanger stateChanger)
		{
			_stateChanger = stateChanger;
		}

		public void Enter()
		{
			_inputService.SpacePressed += ChangeToJumpState;
			_heroAnimator.PlayMove();
		}

		public void Exit()
		{
			_mover.Move(0, Vector3.zero);
			_inputService.SpacePressed -= ChangeToJumpState;
		}

		public void FixedUpdate(float deltaTime)
		{
			_mover.Move(_heroView.PlayerSetting.MoveSpeed, _inputService.Direction.normalized);
		}

		public void Update(float deltaTime)
		{
			Vector2 direction = _inputService.Direction;
			
			if (direction.sqrMagnitude >Epsilon)
				_rotator.RotateToMoveDirection(direction, _heroView.PlayerSetting.RotateSpeed * deltaTime);

			if (Vector2.SqrMagnitude(_inputService.Direction) < Epsilon)
				_stateChanger.ChangeState<HeroIdleState>(); 
		}

		private void ChangeToJumpState()
		{
			_stateChanger.ChangeState<HeroJumpState>();
		}
	}
}