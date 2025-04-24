using System.Collections.Generic;
using Cat.Characters.Enemies;
using Cat.Characters.Enemies.Animations;
using Cat.Characters.Enemies.States;
using Cat.Characters.FSM.Implementation;
using Cat.Characters.FSM.Interfaces.States;
using Cat.Characters.Player;
using Cat.Characters.Services.Implementation;
using Cat.Characters.Services.Interfaces;

namespace Cat.Characters.FSM.Factories
{
	public class CompanionStateMachineFactory
	{
		private readonly IHeroView _heroView;
		private readonly IMover _mover;
		private readonly ICompanionView _companionView;

		public CompanionStateMachineFactory(ICompanionAnimator companionAnimator, IHeroView heroView, IMover mover, ICompanionView companionView)
		{
			_heroView = heroView;
			_mover = mover;
			_companionView = companionView;
		}

		public StateMachine Create()
		{
			IRotator rotator = new Rotator(_heroView.transform);

			List<IExitableState> states =new List<IExitableState>
			{
				new CompanionIdleState(_heroView, _companionView),
				new CompanionMoveState(_heroView, _mover, _companionView, rotator)
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