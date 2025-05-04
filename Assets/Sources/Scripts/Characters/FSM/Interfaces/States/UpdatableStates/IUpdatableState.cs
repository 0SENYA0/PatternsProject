namespace Sources.Scripts.Characters.FSM.Interfaces.States.UpdatableStates
{
	public interface IUpdatableState : IExitableState
	{
		void Update(float deltaTime);
	}
}