using UnityEngine;
using System;
using System.Collections;

public class ShotFiredState : TurnState {

    public ShotFiredState(TurnStateMachine machine) : base(machine, State.ShotFired)
    {
    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate(Tank currentTank)
    {
    }

    public override void RegisterProjectile(Projectile projectile)
    {
        projectile.onImpact += (pos) =>
        {
            machine.ChangeStateDeferred(State.ShotImpacted);
        };
    }
}
