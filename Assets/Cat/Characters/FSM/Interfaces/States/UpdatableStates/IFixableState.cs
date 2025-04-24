namespace Cat.Characters.FSM.Interfaces.States.UpdatableStates
{
	public interface IFixableState : IExitableState
	{
		void FixedUpdate(float deltaTime);
	}
}