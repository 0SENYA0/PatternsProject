using Sources.Scripts.Characters.FSM.Implementation;

namespace Sources.Scripts.Characters.FSM.Interfaces.States
{
	public interface IExitableState
	{
		void SetStateChanger(IStateChanger stateChanger);
		void Exit();
	}
}