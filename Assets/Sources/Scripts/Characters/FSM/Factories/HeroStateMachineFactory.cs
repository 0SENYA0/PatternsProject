using System.Collections.Generic;
using Sources.Scripts.Cameras;
using Sources.Scripts.Characters.FSM.Implementation;
using Sources.Scripts.Characters.FSM.Interfaces.States;
using Sources.Scripts.Characters.Player;
using Sources.Scripts.Characters.Player.Animations;
using Sources.Scripts.Characters.Player.Input.Interfaces;
using Sources.Scripts.Characters.Player.States.Implementation;
using Sources.Scripts.Characters.Services.Implementation;
using Sources.Scripts.Characters.Services.Interfaces;

namespace Sources.Scripts.Characters.FSM.Factories
{
	public class HeroStateMachineFactory
	{
		private readonly IInputService _inputService;
		private readonly IHeroAnimator _heroAnimator;
		private readonly IMover _mover;
		private readonly IHeroView _heroView;
		private readonly IJumper _jumper;
		private readonly ICameraView _cameraView;

		public HeroStateMachineFactory(IInputService inputService, IHeroAnimator heroAnimator, IMover mover, IHeroView heroView, IJumper jumper, ICameraView cameraView)
		{
			_heroAnimator = heroAnimator;
			_mover = mover;
			_heroView = heroView;
			_jumper = jumper;
			_cameraView = cameraView;
			_inputService = inputService;
		}
		
		public StateMachine Create()
		{
			IRotator rotator = new Rotator();
			
			List<IExitableState> states =new List<IExitableState>
			{
				new HeroIdleState(_inputService, _heroAnimator, _heroView.ObstacleChecker),
				new HeroMoveState(_inputService, _heroAnimator, _mover, rotator, _heroView, _cameraView),
				new HeroJumpState(_heroAnimator, _heroView.ObstacleChecker, _jumper, _heroView)
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