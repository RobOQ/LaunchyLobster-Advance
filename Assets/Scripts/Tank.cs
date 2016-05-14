using UnityEngine;

public class Tank : MonoBehaviour
{
    public GameObject TankBody;
    public GameObject TankHood;
    public GameObject TankGun;
    public GameObject UnmovableYAxis;

    public GameObject GunFirePrefab;
    public GameObject CannonBallPrefab;

    public float CannonPower;

    Vector3 GunFireOffset = new Vector3(0.0f, 1.31f, 0.0f);
    Vector3 GunFireRotation = new Vector3(270.0f, 0.0f, 0.0f);

    MeshRenderer tankBodyRenderer;
    MeshRenderer tankHoodRenderer;
    MeshRenderer tankGunRenderer;

    const float minVerticalRotation = 270.0f;

    GameObject gunfireParticleObject;
    ParticleSystem gunFireParticleSystem;

    void Awake()
    {
        tankBodyRenderer = TankBody.GetComponent<MeshRenderer>();
        tankHoodRenderer = TankHood.GetComponent<MeshRenderer>();
        tankGunRenderer = TankGun.GetComponent<MeshRenderer>();

        gunfireParticleObject = (GameObject)Instantiate(GunFirePrefab, TankGun.transform.position, Quaternion.identity);
        gunfireParticleObject.transform.SetParent(TankGun.transform);
        gunfireParticleObject.transform.localPosition += GunFireOffset;
        gunfireParticleObject.transform.localRotation = Quaternion.Euler(GunFireRotation);

        gunFireParticleSystem = gunfireParticleObject.GetComponent<ParticleSystem>();
    }

    public void SetColor(Color color)
    {
        tankBodyRenderer.material.color = color;
        tankHoodRenderer.material.color = color;
        tankGunRenderer.material.color = color;
    }

    public void TurnTurret(float horizontal, float vertical)
    {
        float resultingZ = TankHood.transform.rotation.eulerAngles.z - vertical;

        if (resultingZ > 0.0f && resultingZ < minVerticalRotation / 2.0f)
        {
            resultingZ = 0.0f;
        }
        else if(resultingZ > minVerticalRotation / 2.0f && resultingZ < minVerticalRotation)
        {
            resultingZ = minVerticalRotation;
        }

        UnmovableYAxis.transform.Rotate(new Vector3(0.0f, horizontal, 0.0f));

        TankHood.transform.localRotation = Quaternion.AngleAxis(resultingZ, new Vector3(0.0f, 0.0f, 1.0f));
    }

    public GameObject FireGun()
    {
        gunFireParticleSystem.Play();

        GameObject cannonBall = Instantiate(CannonBallPrefab);
        cannonBall.transform.position = gunfireParticleObject.transform.position;

        cannonBall.GetComponent<Rigidbody>().AddForce((cannonBall.transform.position - TankHood.transform.position).normalized * CannonPower, ForceMode.Impulse);

        return cannonBall;
    }
}
