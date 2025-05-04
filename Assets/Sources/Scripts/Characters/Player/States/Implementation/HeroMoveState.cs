using Sources.Scripts.Cameras;
using Sources.Scripts.Characters.FSM.Interfaces;
using Sources.Scripts.Characters.FSM.Interfaces.States;
using Sources.Scripts.Characters.FSM.Interfaces.States.UpdatableStates;
using Sources.Scripts.Characters.Player.Animations;
using Sources.Scripts.Characters.Player.Input.Interfaces;
using Sources.Scripts.Characters.Services.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Player.States.Implementation
{
	public class HeroMoveState : IExitableState, IEnterableState, IUpdatableState, IFixableState
	{
		private const float Epsilon = 0.001f;

		private readonly IInputService _inputService;
		private readonly IHeroAnimator _heroAnimator;
		private readonly IMover _mover;
		private readonly IRotator _rotator;
		private readonly IHeroView _heroView;
		private readonly ICameraView _cameraView;
		private IStateChanger _stateChanger;

		public HeroMoveState(IInputService inputService, IHeroAnimator heroAnimator, IMover mover, IRotator rotator, IHeroView heroView, ICameraView cameraView)
		{
			_inputService = inputService;
			_heroAnimator = heroAnimator;
			_mover = mover;
			_rotator = rotator;
			_heroView = heroView;
			_cameraView = cameraView;
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
			_inputService.SpacePressed -= ChangeToJumpState;
		}

		public void FixedUpdate(float deltaTime)
		{
			Vector3 direction = CalculateMoveDirection();
			_mover.Move(_heroView.PlayerSetting.MoveSpeed * deltaTime, direction.normalized);
		}

		public void Update(float deltaTime)
		{
			if (Vector2.SqrMagnitude(_inputService.Direction) < Epsilon)
			{
				_stateChanger.ChangeState<HeroIdleState>();
				return;
			}

			Vector3 direction = CalculateMoveDirection();

			_rotator.RotateToDirection(_heroView.transform, direction, _heroView.PlayerSetting.RotateSpeed * deltaTime);
		}

		private void ChangeToJumpState()
		{
			_stateChanger.ChangeState<HeroJumpState>();
		}

		private Vector3 CalculateMoveDirection()
		{
			Vector3 cameraForward = _cameraView.transform.forward;
			Vector3 cameraRight = _cameraView.transform.right;

			cameraForward.y = 0f;
			cameraRight.y = 0f;

			cameraForward.Normalize();
			cameraRight.Normalize();

			Vector3 moveDirection = cameraForward * _inputService.Direction.y + cameraRight * _inputService.Direction.x;
			return moveDirection;
		}
	}
}