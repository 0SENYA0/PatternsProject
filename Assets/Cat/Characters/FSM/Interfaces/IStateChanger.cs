using Cat.Characters.FSM.Interfaces.States;

namespace Cat.Characters.FSM.Interfaces
{
	public interface IStateChanger
	{
		void ChangeState<T>() where T : IExitableState;

		void ChangeState<TState, TPayload>()
			where TState : IEnterablePayloadState<TPayload>, IExitableState
			where TPayload : IPayload;
	}
}