using System.Collections.Generic;
using Sources.Scripts.Characters.Companions;
using Sources.Scripts.Characters.Companions.Animations;
using Sources.Scripts.Characters.Companions.States;
using Sources.Scripts.Characters.FSM.Implementation;
using Sources.Scripts.Characters.FSM.Interfaces.States;
using Sources.Scripts.Characters.Player;
using Sources.Scripts.Characters.Services.Implementation;
using Sources.Scripts.Characters.Services.Interfaces;

namespace Sources.Scripts.Characters.FSM.Factories
{
	public class CompanionStateMachineFactory
	{
		private readonly ICompanionAnimator _companionAnimator;
		private readonly IHeroView _heroView;
		private readonly IMover _mover;
		private readonly ICompanionView _companionView;

		public CompanionStateMachineFactory(ICompanionAnimator companionAnimator, IHeroView heroView, IMover mover, ICompanionView companionView)
		{
			_companionAnimator = companionAnimator;
			_heroView = heroView;
			_mover = mover;
			_companionView = companionView;
		}

		public StateMachine Create()
		{
			IRotator rotator = new Rotator();

			List<IExitableState> states =new List<IExitableState>
			{
				new CompanionIdleState(_heroView, _companionView, _companionAnimator),
				new CompanionMoveState(_heroView, _mover, _companionView, rotator, _companionAnimator)
			};

			StateMachine stateMachine = new StateMachine(states);

			foreach (IExitableState state in states)
			{
				state.SetStateChanger(stateMachine);
			}

			stateMachine.ChangeState<CompanionIdleState>();
			
			return stateMachine; 
		}
	}
}