using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    List<Tank> tanks;

    int turnIndex;

    bool hasGameStarted;

    public Vector3 CameraOffset;
    public Vector3 CameraRelativeRotation;

    void Awake()
    {
        hasGameStarted = false;
        tanks = new List<Tank>();
        turnIndex = 0;
    }

    public void RegisterPlayer(Tank tank)
    {
        tanks.Add(tank);
    }

    public void Update()
    {
        if (!hasGameStarted)
        {
            StartTurn(turnIndex);
            hasGameStarted = true;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        tanks[turnIndex].TurnTurret(horizontal, vertical);

        if (Input.GetButtonDown("FireCannon"))
        {
            tanks[turnIndex].FireGun();
            turnIndex = (turnIndex + 1) % tanks.Count;
            StartTurn(turnIndex);
        }
    }

    public void StartTurn(int tankIndex)
    {
        Camera.main.transform.SetParent(tanks[tankIndex].UnmovableYAxis.transform);
        Camera.main.transform.localPosition = CameraOffset;
        Camera.main.transform.localRotation = Quaternion.Euler(CameraRelativeRotation);
    }
}
