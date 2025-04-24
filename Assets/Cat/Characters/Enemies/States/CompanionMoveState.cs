using System.Transactions;
using Cat.Characters.FSM.Interfaces;
using Cat.Characters.FSM.Interfaces.States;
using Cat.Characters.FSM.Interfaces.States.UpdatableStates;
using Cat.Characters.Player;
using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Enemies.States
{
	public class CompanionMoveState : IExitableState, IEnterableState, IUpdatableState, IFixableState
	{
		private readonly IHeroView _heroView;
		private readonly IMover _mover;
		private readonly ICompanionView _companionView;
		private readonly IRotator _rotator;
		private float _speed = 4f;
		private IStateChanger _stateChanger;
		private float _distanceToReach = 2f;

		public CompanionMoveState(IHeroView heroView, IMover mover, ICompanionView companionView, IRotator rotator)
		{
			_heroView = heroView;
			_mover = mover;
			_companionView = companionView;
			_rotator = rotator;
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
			_mover.Move(_speed, GetDirection());
		}

		public void Update(float deltaTime)
		{
			if (Vector3.Distance(_heroView.transform.position, _companionView.transform.position) <= _distanceToReach)
				_stateChanger.ChangeState<CompanionIdleState>();

			_rotator.RotateToDirection(_heroView.transform.position, _companionView.transform.position);
		}

		private Vector3 GetDirection() =>
			(_heroView.transform.position - _companionView.transform.position).normalized;
	}
}