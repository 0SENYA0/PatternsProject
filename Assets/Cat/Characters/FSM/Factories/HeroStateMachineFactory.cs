using System.Collections.Generic;
using Cat.Characters.FSM.Implementation;
using Cat.Characters.FSM.Interfaces.States;
using Cat.Characters.Player;
using Cat.Characters.Player.Animations;
using Cat.Characters.Player.Input.Interfaces;
using Cat.Characters.Player.States.Implementation;
using Cat.Characters.Services.Implementation;
using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.FSM.Factories
{
	public class HeroStateMachineFactory
	{
		private readonly IInputService _inputService;
		private readonly IHeroAnimator _heroAnimator;
		private readonly IMover _mover;
		private readonly IHeroView _heroView;
		private readonly IJumper _jumper;

		public HeroStateMachineFactory(IInputService inputService, IHeroAnimator heroAnimator, IMover mover, IHeroView heroView, IJumper jumper)
		{
			_heroAnimator = heroAnimator;
			_mover = mover;
			_heroView = heroView;
			_jumper = jumper;
			_inputService = inputService;
		}
		
		public StateMachine Create()
		{
			IRotator rotator = new Rotator(_heroView.transform);
			
			List<IExitableState> states =new List<IExitableState>
			{
				new HeroIdleState(_inputService, _heroAnimator, _heroView.ObstacleChecker, rotator, _heroView),
				new HeroMoveState(_inputService, _heroAnimator, _mover, rotator, _heroView),
				//new AttackState(_heroAnimator),
				new HeroJumpState(_heroAnimator, _heroView.ObstacleChecker, _jumper, rotator, _heroView)
			};

			StateMachine stateMachine = new StateMachine(states);

			foreach (IExitableState state in states)
			{
				state.SetStateChanger(stateMachine);
			}

			stateMachine.ChangeState<HeroIdleState>();
			
			return stateMachine; 
		}
	}
}