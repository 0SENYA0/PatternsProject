using Sources.Scripts.Characters.Companions.Animations;
using Sources.Scripts.Characters.FSM.Implementation;
using Sources.Scripts.Characters.FSM.Interfaces;
using UnityEngine;

namespace Sources.Scripts.Characters.Companions
{
	public class Companion : MonoBehaviour, ICompanionView
	{
		[SerializeField] private CompanionAnimator _companionAnimator;
		[SerializeField] private CompanionSetting _companionSetting;
		[field: SerializeField] public Rigidbody Rigidbody { get; private set; }
		
		private StateMachine _stateMachine;
		private IStateMachineUpdater _stateMachineUpdater;

		public ICompanionAnimator Animator => _companionAnimator;

		public ICompanionSetting CompanionSetting => _companionSetting;


		public void Construct(IStateMachineUpdater stateMachineUpdater)
		{
			_stateMachineUpdater = stateMachineUpdater;
		}
		
		private void Update() =>
			_stateMachineUpdater.UpdateState(Time.deltaTime);

		private void FixedUpdate() =>
			_stateMachineUpdater.FixedUpdateState(Time.fixedDeltaTime);
		
		private void LateUpdate() =>
			_stateMachineUpdater.LateUpdateState(Time.deltaTime);
	}
}