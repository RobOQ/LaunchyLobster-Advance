using UnityEngine;
using System.Collections;

public abstract class TurnState
{
    public enum State
    {
        WaitingForShot,
        ShotFired,
        ShotImpacted,
        EndOfTurn
    }

    public State state;
    protected TurnStateMachine machine;

    public TurnState(TurnStateMachine machine, State state)
    {
        this.machine = machine;
        this.state = state;
    }

    public abstract void OnEnter();
    public abstract void OnUpdate(Tank currentTank);
    public abstract void OnExit();

    public virtual void RegisterProjectile(Projectile projectile)
    {
    }
}
