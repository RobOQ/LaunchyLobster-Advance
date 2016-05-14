using UnityEngine;
using System.Collections;
using System;

public class WaitingForShotState : TurnState
{
    public WaitingForShotState(TurnStateMachine machine) : base(machine, State.WaitingForShot)
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        currentTank.TurnTurret(horizontal, vertical);

        if (Input.GetButtonDown("FireCannon"))
        {
            GameObject projectileObj = currentTank.FireGun();
            Projectile projectile = projectileObj.GetComponent<Projectile>();
            machine.RegisterProjectile(projectile);
            machine.ChangeStateDeferred(State.ShotFired);
        }
    }
}
