using Sources.Scripts.Characters.Commons;
using Sources.Scripts.Characters.Companions.Animations;
using Sources.Scripts.Characters.FSM.Interfaces;
using Sources.Scripts.Characters.FSM.Interfaces.States;
using Sources.Scripts.Characters.FSM.Interfaces.States.UpdatableStates;
using Sources.Scripts.Characters.Player;
using Sources.Scripts.Extensions;

namespace Sources.Scripts.Characters.Companions.States
{
	public class CompanionIdleState : IExitableState, IEnterableState, IUpdatableState
	{
		private readonly IHeroView _heroView;
		private readonly ICompanionView _companionView;
		private readonly ICompanionAnimator _companionAnimator;

		private IStateChanger _stateChanger;

		public CompanionIdleState(IHeroView heroView, ICompanionView companionView, ICompanionAnimator companionAnimator)
		{
			_heroView = heroView;
			_companionView = companionView;
			_companionAnimator = companionAnimator;
		}

		public void SetStateChanger(IStateChanger stateChanger) =>
			_stateChanger = stateChanger;

		public void Enter() =>
			_companionAnimator.PlayMove(0f);

		public void Exit()
		{ }

		public void Update(float deltaTime)
		{
			if (_companionView.transform.position.SqrDistance(_heroView.transform.position) >= _companionView.CompanionSetting.DistanceToWalk)
				_stateChanger.ChangeState<CompanionMoveState>();
		}
	}
}