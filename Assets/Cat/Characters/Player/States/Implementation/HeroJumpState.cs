using Cat.Characters.FSM.Interfaces;
using Cat.Characters.FSM.Interfaces.States;
using Cat.Characters.FSM.Interfaces.States.UpdatableStates;
using Cat.Characters.Player.Animations;
using Cat.Characters.Player.Input.Interfaces;
using Cat.Characters.Player.Settings;
using Cat.Characters.Services;
using Cat.Characters.Services.Implementation;
using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat.Characters.Player.States.Implementation
{
	public class HeroJumpState : IExitableState, IEnterableState, IUpdatableState
	{
		private readonly IHeroAnimator _heroAnimator;
		private readonly IObstacleChecker _groundChecker;
		private readonly IJumper _jumper;
		private readonly IRotator _rotator;
		private readonly IHeroView _heroView;

		private IStateChanger _stateChanger;
		private bool _hasLeftGround;

		public HeroJumpState(IHeroAnimator heroAnimator, IObstacleChecker groundChecker, IJumper jumper, IRotator rotator, IHeroView heroView)
		{
			_heroAnimator = heroAnimator;
			_groundChecker = groundChecker;
			_jumper = jumper;
			_rotator = rotator;
			_heroView = heroView;
		}

		public void SetStateChanger(IStateChanger stateChanger)
		{
			_stateChanger = stateChanger;
		}

		public void Enter()
		{
			_hasLeftGround = false;
			
			_heroAnimator.PlayJump();
			_jumper.Jump(_heroView.PlayerSetting.JumpForce);
		}

		public void Exit()
		{ }

		public void Update(float deltaTime)
		{
			_rotator.RotateToMouse(_heroView.PlayerSetting.RotateSpeed * deltaTime);
			
			if (_hasLeftGround == false)
			{
				if (_jumper.Velocity.y > 0.01f)
					_hasLeftGround = true;
				
				return;
			}

			if (_hasLeftGround && _groundChecker.IsCollided && _jumper.Velocity.y <= 0.1f)
			{
				_stateChanger.ChangeState<HeroIdleState>();
			}
		}
	}
}