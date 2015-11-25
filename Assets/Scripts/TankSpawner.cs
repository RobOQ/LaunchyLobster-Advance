using UnityEngine;
using System.Collections;

public class TankSpawner : MonoBehaviour
{
    public int NumberOfTanks;
    public GameObject TankPrefab;

    public Color[] TankColors;

    Tank[] tanks;

    const int MaxNumberOfTanks = 64;

    // Use this for initialization
    void Start()
    {
        if (NumberOfTanks > MaxNumberOfTanks)
        {
            NumberOfTanks = MaxNumberOfTanks;
        }

        tanks = new Tank[NumberOfTanks];
        for (int i = 0; i < NumberOfTanks; ++i)
        {
            GameObject newTankObject = Instantiate(TankPrefab);
            newTankObject.name = "Tank" + i.ToString("D2");
            Vector3 position = SelectStartingPositionForTank(i);

            newTankObject.transform.position = position;
            float yRotation = Random.Range(0.0f, 360.0f);
            Quaternion rotation = Quaternion.AngleAxis(yRotation, Vector3.up);
            newTankObject.transform.rotation = rotation;

            Tank newTank = newTankObject.GetComponent<Tank>();

            if (TankColors.Length > 0)
            {
                newTank.SetColor(TankColors[i % TankColors.Length]);
            }

            tanks[i] = newTank;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    Vector3 SelectStartingPositionForTank(int tankNumber)
    {
        Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));

        for (int existingTankIndex = 0; existingTankIndex < tankNumber; ++existingTankIndex)
        {
            while (Vector3.Distance(position, tanks[existingTankIndex].transform.position) < 1.5f)
            {
                position = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
                existingTankIndex = 0;
            }
        }

        return position;
    }
}
