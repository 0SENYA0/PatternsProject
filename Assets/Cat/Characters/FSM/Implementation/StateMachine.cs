using System;
using System.Collections.Generic;
using System.Linq;
using Cat.Characters.FSM.Interfaces;
using Cat.Characters.FSM.Interfaces.States;
using Cat.Characters.FSM.Interfaces.States.UpdatableStates;
using UnityEngine;

namespace Cat.Characters.FSM.Implementation
{
	public class StateMachine : IStateChanger, IStateMachineUpdater
	{
		private readonly Dictionary<Type, IExitableState> _states;

		private IExitableState _currentState;

		public StateMachine(List<IExitableState> states)
		{
			_states = states.ToDictionary(type => type.GetType(), value => value);
		}

		public void UpdateState(float deltaTime)
		{
			if (_currentState is IUpdatableState updatableState)
				updatableState.Update(deltaTime);
		}

		public void FixedUpdateState(float deltaTime)
		{
			if (_currentState is IFixableState fixedState)
				fixedState.FixedUpdate(deltaTime);
		}

		public void LateUpdateState(float deltaTime)
		{
			if (_currentState is ILatableState fixedState)
				fixedState.LateUpdate(deltaTime);
		}

		public void ChangeState<T>() where T : IExitableState
		{
			if (_states.TryGetValue(typeof(T), out IExitableState newState))
				ChangeState(newState);
			else
				throw new Exception($"State {typeof(T)} doesnt exist in StateMachine");
		}

		public void ChangeState<TState, TPayload>()
			where TState : IEnterablePayloadState<TPayload>, IExitableState
			where TPayload : IPayload
		{
			if (_states.TryGetValue(typeof(TState), out IExitableState newState))
				ChangeState(newState);
			else
				throw new Exception($"State {typeof(TState)} doesnt exist in StateMachine");
		}

		private void ChangeState(IExitableState newState)
		{
			if(newState == _currentState) 
				return;
			
			_currentState?.Exit();
			_currentState = newState;

			if (_currentState is IEnterableState enterableState)
			{
				enterableState.Enter();
			}
		}
	}
}