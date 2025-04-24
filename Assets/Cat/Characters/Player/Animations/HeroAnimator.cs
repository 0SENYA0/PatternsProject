using System;
using System.Collections.Generic;
using Cat.Characters.Commons;
using UnityEngine;

namespace Cat.Characters.Player.Animations
{
	public class HeroAnimator : MonoBehaviour, IHeroAnimator
	{
		[SerializeField] private Animator _animator;
		
		private Dictionary<string, float> _clipLengths;

		public void Initialize() =>
			CacheClipLengths();

		public float GetClipLength(string clipName)
		{
			if (_clipLengths == null)
				CacheClipLengths();
			
			if (_clipLengths.TryGetValue(clipName, out float length))
				return length;
			
			throw new Exception($"Animation clip '{clipName}' not found in Animator.");
		}

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
		
		private void CacheClipLengths()
		{
			_clipLengths = new Dictionary<string, float>();

			if (_animator.runtimeAnimatorController == null)
			{
				Debug.LogWarning("Animator has no controller assigned.");
				return;
			}

			foreach (AnimationClip clip in _animator.runtimeAnimatorController.animationClips)
			{
				if (_clipLengths.ContainsKey(clip.name) == false)
					_clipLengths[clip.name] = clip.length;
			}
		}
	}
}