namespace Cat.Characters.FSM.Interfaces.States
{
	public interface IEnterablePayloadState<TPayload>  where TPayload : IPayload 
	{
		void Enter(TPayload payload);
	}
}