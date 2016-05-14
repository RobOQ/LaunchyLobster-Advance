using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TurnStateMachine
{
    private TurnState currentState;

    public TurnState CurrentState
    {
        get
        {
            return currentState;
        }

        private set
        {
            currentState = value;
        }
    }

    private Nullable<TurnState.State> nextState;

    public Nullable<TurnState.State> NextState
    {
        get
        {
            return nextState;
        }

        private set
        {
            nextState = value;
        }
    }

    Dictionary<TurnState.State, TurnState> states;

    public TurnStateMachine()
    {
        states = new Dictionary<TurnState.State, TurnState>();

        // Could be the work of a StateFactory or something like that.
        // For now, we'll just do it here.
        foreach (TurnState.State state in Enum.GetValues(typeof(TurnState.State)))
        {
            switch (state)
            {
                case TurnState.State.WaitingForShot:
                    {
                        states.Add(state, new WaitingForShotState(this));
                        break;
                    }
                case TurnState.State.ShotFired:
                    {
                        states.Add(state, new ShotFiredState(this));
                        break;
                    }
                case TurnState.State.ShotImpacted:
                    {
                        states.Add(state, new ShotImpactedState(this));
                        break;
                    }
                case TurnState.State.EndOfTurn:
                    {
                        states.Add(state, new EndOfTurnState(this));
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException("Haven't added " + state.ToString() + " to the states in TurnStateMachine");
                    }
            }
        }

        NextState = null;
    }

    public void RegisterProjectile(Projectile projectile)
    {
        foreach (TurnState state in states.Values)
        {
            state.RegisterProjectile(projectile);
        }
    }

    public void ChangeStateDeferred(TurnState.State newState)
    {
        if (CurrentState == null || newState != CurrentState.state)
        {
            NextState = newState;
        }
    }

    public void ChangeStateImmediate(TurnState.State newState)
    {
        if (CurrentState == null || newState != CurrentState.state)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }
            CurrentState = states[newState];
            CurrentState.OnEnter();
            // Assume that if we just forced a state change, we don't want to obey any
            // lingering state change request on the next frame.
            NextState = null;
        }
    }

    public bool Update(Tank currentTank)
    {
        if (CurrentState != null)
        {
            CurrentState.OnUpdate(currentTank);
        }

        if (NextState != null && (CurrentState == null || NextState != CurrentState.state))
        {
            ChangeStateImmediate(NextState.Value);
            if (currentState.state == TurnState.State.EndOfTurn)
            {
                return true;
            }
        }

        return false;
    }
}
