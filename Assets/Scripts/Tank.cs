using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour
{
    public GameObject TankBody;
    public GameObject TankHood;
    public GameObject TankGun;

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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            TankHood.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TankHood.transform.Rotate(new Vector3(0.0f, -1.0f, 0.0f));
        }
    }

    public void SetColor(Color color)
    {
        tankBodyRenderer.material.color = color;
        tankHoodRenderer.material.color = color;
        tankGunRenderer.material.color = color;
    }
}
