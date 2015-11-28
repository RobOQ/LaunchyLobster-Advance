using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour
{
    public GameObject TankBody;
    public GameObject TankHood;
    public GameObject TankGun;
    public GameObject UnmovableYAxis;

    MeshRenderer tankBodyRenderer;
    MeshRenderer tankHoodRenderer;
    MeshRenderer tankGunRenderer;

    void Awake()
    {
        tankBodyRenderer = TankBody.GetComponent<MeshRenderer>();
        tankHoodRenderer = TankHood.GetComponent<MeshRenderer>();
        tankGunRenderer = TankGun.GetComponent<MeshRenderer>();
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Color color)
    {
        tankBodyRenderer.material.color = color;
        tankHoodRenderer.material.color = color;
        tankGunRenderer.material.color = color;
    }

    public void TurnTurret(float horizontal, float vertical)
    {
        //float resultingZ = TankHood.transform.rotation.eulerAngles.z + vertical;
        //if (resultingZ > 0.0f)
        //{
        //    vertical = 0.0f - TankHood.transform.rotation.eulerAngles.z;
        //}
        //else if (resultingZ < 180.0f)
        //{
        //    vertical = TankHood.transform.rotation.eulerAngles.z - 180.0f;
        //}

        UnmovableYAxis.transform.Rotate(new Vector3(0.0f, horizontal, 0.0f));

        TankHood.transform.Rotate(new Vector3(0.0f, 0.0f, -1.0f * vertical));
    }
}
