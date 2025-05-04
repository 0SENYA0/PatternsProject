using Sources.Scripts.Characters.Commons;
using UnityEngine;

namespace Sources.Scripts.Characters.Companions.Animations
{
	public class CompanionAnimator : MonoBehaviour, ICompanionAnimator
	{
		[SerializeField] private Animator _animator;

		public void PlayMove(float speed)
		{
			_animator.SetFloat(AnimationParameters.CompanionAnimations.SpeedParameter, speed);
		}
	}
}