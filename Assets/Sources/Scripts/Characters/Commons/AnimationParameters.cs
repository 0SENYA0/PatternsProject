using UnityEngine;

namespace Sources.Scripts.Characters.Commons
{
	public static class AnimationParameters
	{
		public class HeroAnimations
		{
			public readonly static int AttackedParameter = Animator.StringToHash("Attacked");
			public readonly static int MovedParameter = Animator.StringToHash("Moved");
			public readonly static int JumpedParameter = Animator.StringToHash("Jumped");
			public readonly static int IdleParameter = Animator.StringToHash("Idle");
		}
		
		public class CompanionAnimations
		{
			public readonly static int SpeedParameter = Animator.StringToHash("Speed");
		}
	}
}