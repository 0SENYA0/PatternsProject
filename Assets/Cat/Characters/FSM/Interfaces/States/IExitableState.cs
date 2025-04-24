namespace Cat.Characters.FSM.Interfaces.States
{
	public interface IExitableState
	{
		void SetStateChanger(IStateChanger stateChanger);
		void Exit();
	}
}