using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    List<Tank> tanks;

    int turnIndex;

    void Awake()
    {
        tanks = new List<Tank>();
        turnIndex = 0;
    }

    public void RegisterPlayer(Tank tank)
    {
        tanks.Add(tank);
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        tanks[turnIndex].TurnTurret(horizontal, vertical);

        if (Input.GetButtonDown("FireCannon"))
        {
            turnIndex = (turnIndex + 1) % tanks.Count;
        }
    }
}
