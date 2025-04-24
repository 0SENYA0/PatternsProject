using Cat.Characters.FSM.Interfaces;
using Cat.Characters.FSM.Interfaces.States;
using Cat.Characters.FSM.Interfaces.States.UpdatableStates;
using Cat.Characters.Player;
using UnityEngine;

namespace Cat.Characters.Enemies.States
{
	public class CompanionIdleState : IExitableState, IEnterableState, IUpdatableState
	{
		private readonly IHeroView _heroView;
		private readonly ICompanionView _companionView;
		
		private IStateChanger _stateChanger;
		private float _distanceToReach = 2f;

		public CompanionIdleState(IHeroView heroView, ICompanionView companionView)
		{
			_heroView = heroView;
			_companionView = companionView;
		}

		public void SetStateChanger(IStateChanger stateChanger)
		{
			_stateChanger = stateChanger;
		}

		public void Enter()
		{ }

		public void Exit()
		{ }

		public void Update(float deltaTime)
		{
			if (Vector3.Distance(_heroView.transform.position, _companionView.transform.position) > _distanceToReach)
				_stateChanger.ChangeState<CompanionMoveState>();
		}
		
		private Vector2 GetDirection() =>
			(_heroView.transform.position - _companionView.transform.position).normalized;
	}
}