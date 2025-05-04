using Sources.Scripts.Characters.Companions;
using Sources.Scripts.Characters.FSM.Factories;
using Sources.Scripts.Characters.FSM.Implementation;
using Sources.Scripts.Characters.Player;
using Sources.Scripts.Characters.Player.Input.Implementation;
using Sources.Scripts.Characters.Player.Input.Interfaces;
using Sources.Scripts.Characters.Player.States.Implementation;
using Sources.Scripts.Characters.Services.Implementation;
using Sources.Scripts.Characters.Services.Interfaces;
using UnityEngine;

namespace Sources.Scripts
{
	public class LevelInitializer : MonoBehaviour
	{
		[SerializeField] private Hero _hero;
		[SerializeField] private Companion _companion;
		[SerializeField] private CameraFollower _cameraFollower;
		
		private void Awake()
		{
			IInputService inputService = new InputService();
			
			_cameraFollower.Construct(_hero.transform, inputService);

			InitializeHero(inputService);
			InitializeCompanion();
		}

		private void InitializeCompanion()
		{
			IMover mover = new RigidbodyMover(_companion.Rigidbody);

			CompanionStateMachineFactory companionStateMachineFactory = new CompanionStateMachineFactory(_companion.Animator, _hero, mover, _companion);
			StateMachine stateMachine = companionStateMachineFactory.Create();
			_companion.Construct(stateMachine);
		}

		private void InitializeHero(IInputService inputService)
		{
			IMover mover = new RigidbodyMover(_hero.Rigidbody);
			IJumper jumper = new Jumper(_hero.Rigidbody);
			HeroStateMachineFactory heroStateMachineFactory = new HeroStateMachineFactory(inputService, _hero.Animator, mover, _hero, jumper, _cameraFollower);
			StateMachine stateMachine = heroStateMachineFactory.Create();
			_hero.Construct(stateMachine, inputService);
		}
	}
}