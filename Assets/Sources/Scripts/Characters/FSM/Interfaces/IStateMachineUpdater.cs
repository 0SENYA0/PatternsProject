namespace Sources.Scripts.Characters.FSM.Interfaces
{
	public interface IStateMachineUpdater
	{
		void LateUpdateState(float deltaTime);

		void FixedUpdateState(float fixedDeltaTime);

		void UpdateState(float deltaTime);
	}
}