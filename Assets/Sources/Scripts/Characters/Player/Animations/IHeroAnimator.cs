namespace Sources.Scripts.Characters.Player.Animations
{
	public interface IHeroAnimator
	{
		void PlayIdle();

		void PlayJump();

		void PlayAttack();

		void PlayMove();
	}
}