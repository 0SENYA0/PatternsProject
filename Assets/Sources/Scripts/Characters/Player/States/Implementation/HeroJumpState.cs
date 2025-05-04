using Sources.Scripts.Characters.FSM.Interfaces;
using Sources.Scripts.Characters.FSM.Interfaces.States;
using Sources.Scripts.Characters.FSM.Interfaces.States.UpdatableStates;
using Sources.Scripts.Characters.Player.Animations;
using Sources.Scripts.Characters.Services.Interfaces;

namespace Sources.Scripts.Characters.Player.States.Implementation
{
	public class HeroJumpState : IExitableState, IEnterableState, IUpdatableState
	{
		private const float Epsilon = 0.01f;
		private readonly IHeroAnimator _heroAnimator;
		private readonly IObstacleChecker _groundChecker;
		private readonly IJumper _jumper;
		private readonly IHeroView _heroView;

		private IStateChanger _stateChanger;
		private bool _hasLeftGround;

		public HeroJumpState(IHeroAnimator heroAnimator, IObstacleChecker groundChecker, IJumper jumper, IHeroView heroView)
		{
			_heroAnimator = heroAnimator;
			_groundChecker = groundChecker;
			_jumper = jumper;
			_heroView = heroView;
		}

		public void SetStateChanger(IStateChanger stateChanger)
		{
			_stateChanger = stateChanger;
		}

		public void Enter()
		{
			_heroAnimator.PlayJump();
			_jumper.Jump(_heroView.PlayerSetting.JumpForce);
		}

		public void Exit()
		{
			_hasLeftGround = false;
		}

		public void Update(float deltaTime)
		{
			if (_hasLeftGround == false)
			{
				if (_jumper.Velocity.y > Epsilon)
					_hasLeftGround = true;
				
				return;
			}

			if (_hasLeftGround && _groundChecker.IsCollided && _jumper.Velocity.y <= Epsilon)
			{
				_stateChanger.ChangeState<HeroIdleState>();
			}
		}
	}
}