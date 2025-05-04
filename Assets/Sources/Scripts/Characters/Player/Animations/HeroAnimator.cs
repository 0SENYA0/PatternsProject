using Sources.Scripts.Characters.Commons;
using UnityEngine;

namespace Sources.Scripts.Characters.Player.Animations
{
	public class HeroAnimator : MonoBehaviour, IHeroAnimator
	{
		[SerializeField] private Animator _animator;
		
		public void PlayIdle()
		{
			_animator.SetTrigger(AnimationParameters.HeroAnimations.IdleParameter);
		}

		public void PlayJump()
		{
			_animator.SetTrigger(AnimationParameters.HeroAnimations.JumpedParameter);
		}
		
		public void PlayAttack()
		{
			_animator.SetTrigger(AnimationParameters.HeroAnimations.AttackedParameter);
		}

		public void PlayMove()
		{
			_animator.SetTrigger(AnimationParameters.HeroAnimations.MovedParameter);
		}
	}
}