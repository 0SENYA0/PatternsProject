using Cat.Characters.FSM.Interfaces.States;

namespace Cat.Characters.Player.Animations
{
	public interface IHeroAnimator : IPayload
	{
		void PlayIdle();

		void PlayJump();

		void PlayAttack();

		void PlayMove();

		float GetClipLength(string animationName);
	}
}