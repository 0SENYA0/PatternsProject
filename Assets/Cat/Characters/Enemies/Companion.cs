using Cat.Characters.Enemies.Animations;
using Cat.Characters.FSM.Implementation;
using Cat.Characters.FSM.Interfaces;
using UnityEngine;

namespace Cat.Characters.Enemies
{
	public class Companion : MonoBehaviour, ICompanionView
	{
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private CompanionAnimator _companionAnimator;

		private StateMachine _stateMachine;
		private IStateMachineUpdater _stateMachineUpdater;

		public ICompanionAnimator Animator => _companionAnimator;

		public Rigidbody Rigidbody => _rigidbody;

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