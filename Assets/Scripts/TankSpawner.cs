using UnityEngine;
using System.Collections;

public class TankSpawner : MonoBehaviour
{
    public int NumberOfTanks;
    public GameObject TankPrefab;

    public Color[] TankColors;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < NumberOfTanks; ++i)
        {
            GameObject newTankObject = Instantiate(TankPrefab);
            newTankObject.name = "Tank" + i.ToString("D2");
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));
            newTankObject.transform.position = position;
            float yRotation = Random.Range(0.0f, 360.0f);
            Quaternion rotation = Quaternion.AngleAxis(yRotation, Vector3.up);
            newTankObject.transform.rotation = rotation;

            Tank newTank = newTankObject.GetComponent<Tank>();

            newTank.SetColor(TankColors[i % TankColors.Length]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
