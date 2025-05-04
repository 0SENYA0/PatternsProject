using Sources.Scripts.Characters.Commons;
using Sources.Scripts.Characters.Companions.Animations;
using Sources.Scripts.Characters.FSM.Interfaces;
using Sources.Scripts.Characters.FSM.Interfaces.States;
using Sources.Scripts.Characters.FSM.Interfaces.States.UpdatableStates;
using Sources.Scripts.Characters.Player;
using Sources.Scripts.Characters.Services.Interfaces;
using Sources.Scripts.Extensions;
using UnityEngine;

namespace Sources.Scripts.Characters.Companions.States
{
	public class CompanionMoveState : IExitableState, IEnterableState, IUpdatableState, IFixableState
	{
		private readonly IHeroView _heroView;
		private readonly IMover _mover;
		private readonly ICompanionView _companionView;
		private readonly IRotator _rotator;
		private readonly ICompanionAnimator _companionAnimator;
		private IStateChanger _stateChanger;
		private float _moveSpeed;
		
		public CompanionMoveState(IHeroView heroView, IMover mover, ICompanionView companionView, IRotator rotator, ICompanionAnimator companionAnimator)
		{
			_heroView = heroView;
			_mover = mover;
			_companionView = companionView;
			_rotator = rotator;
			_companionAnimator = companionAnimator;
		}

		public void SetStateChanger(IStateChanger stateChanger)
		{
			_stateChanger = stateChanger;
		}

		public void Exit()
		{
		}

		public void Enter()
		{
		}

		public void FixedUpdate(float deltaTime)
		{
			_mover.Move(_moveSpeed * deltaTime, GetDirection());
		}

		public void Update(float deltaTime)
		{
			float distance = _companionView.transform.position.SqrDistance(_heroView.transform.position);

			if (distance < _companionView.CompanionSetting.DistanceToWalk)
			{
				_stateChanger.ChangeState<CompanionIdleState>();
				return;
			}

			if (distance >= _companionView.CompanionSetting.DistanceToRun)
				ChangeMovementSpeed(deltaTime, _companionView.CompanionSetting.MaxSpeed);
			else
				ChangeMovementSpeed(deltaTime, _companionView.CompanionSetting.MinSpeed);

			_companionAnimator.PlayMove(_moveSpeed);
			
			_rotator.RotateToDirection(_companionView.transform, GetDirection(), _companionView.CompanionSetting.RotateSpeed * deltaTime);
		}

		private void ChangeMovementSpeed(float deltaTime, float targetSpeed) =>
			_moveSpeed = Mathf.MoveTowards(_moveSpeed, targetSpeed, _companionView.CompanionSetting.Acceleration * deltaTime);

		private Vector3 GetDirection() =>
			(_heroView.transform.position - _companionView.transform.position).normalized;
	}
}