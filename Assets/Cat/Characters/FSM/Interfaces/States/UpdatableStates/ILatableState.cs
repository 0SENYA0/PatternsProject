namespace Cat.Characters.FSM.Interfaces.States.UpdatableStates
{
	public interface ILatableState : IExitableState
	{
		void LateUpdate(float deltaTime);
	}
}