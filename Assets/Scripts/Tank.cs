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

    }

    public void SetColor(Color color)
    {
        tankBodyRenderer.material.color = color;
        tankHoodRenderer.material.color = color;
        tankGunRenderer.material.color = color;
    }
}
