namespace Sources.Scripts.Characters.FSM.Interfaces.States.UpdatableStates
{
	public interface ILatableState : IExitableState
	{
		void LateUpdate(float deltaTime);
	}
}