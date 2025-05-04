using Sources.Scripts.Characters.Commons;
using Sources.Scripts.Characters.FSM.Interfaces;
using Sources.Scripts.Characters.FSM.Interfaces.States;
using Sources.Scripts.Characters.FSM.Interfaces.States.UpdatableStates;
using Sources.Scripts.Characters.Player.Animations;

namespace Sources.Scripts.Characters.Player.States.Implementation
{
	public class AttackState : IExitableState, IEnterableState, IUpdatableState
	{
		private readonly IHeroAnimator _heroAnimator;
		private float _attackAnimationLength;

		private IStateChanger _stateChanger;

		public AttackState(IHeroAnimator heroAnimator)
		{
			_heroAnimator = heroAnimator;
		}

		public void SetStateChanger(IStateChanger stateChanger)
		{
			_stateChanger = stateChanger;
		}

		public void Enter()
		{
			//			_attackAnimationLength = _heroAnimator.GetClipLength(AnimationParameters.HeroAnimations.AttackAnimationName);
			_heroAnimator.PlayAttack();
		}

		public void Exit()
		{
		}

		public void Update(float deltaTime)
		{
			_attackAnimationLength -= deltaTime;
			
			if (_attackAnimationLength < 0)
				_stateChanger.ChangeState<HeroIdleState>();
		}
	}
}