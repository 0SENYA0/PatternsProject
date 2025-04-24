using UnityEngine;

namespace Cat.Characters.Commons
{
	public static class AnimationParameters
	{
		public class HeroAnimations
		{
			public readonly static int AttackedParameter = Animator.StringToHash("Attacked");
			public readonly static int MovedParameter = Animator.StringToHash("Moved");
			public readonly static int JumpedParameter = Animator.StringToHash("Jumped");
			public readonly static int IdleParameter = Animator.StringToHash("Idle");

			public const string AttackAnimationName = "Standing Melee Attack 360 High";
			public const string MoveAnimationName = "Slow Run";
			public const string JumpAnimationName = "Jumping";
			public const string IdleAnimationName = "Idle";
		}
	}
}