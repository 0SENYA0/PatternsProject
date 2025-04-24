using Cat.Characters.Enemies;
using Cat.Characters.FSM.Factories;
using Cat.Characters.FSM.Implementation;
using Cat.Characters.Player;
using Cat.Characters.Player.Input.Implementation;
using Cat.Characters.Player.Input.Interfaces;
using Cat.Characters.Services.Implementation;
using Cat.Characters.Services.Interfaces;
using UnityEngine;

namespace Cat
{
	public class LevelInitializer : MonoBehaviour
	{
		[SerializeField] private Hero _hero;
		[SerializeField] private Companion _companion;
		[SerializeField] private CameraFollower _cameraFollower;
		
		private void Awake()
		{
			_cameraFollower.Construct(_hero.transform);

			IInputService inputService = new InputService();
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
			HeroStateMachineFactory heroStateMachineFactory = new HeroStateMachineFactory(inputService, _hero.Animator, mover, _hero, jumper);
			StateMachine stateMachine = heroStateMachineFactory.Create();
			_hero.Construct(stateMachine, inputService);
		}
	}
}