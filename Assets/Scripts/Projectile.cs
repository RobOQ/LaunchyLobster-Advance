using UnityEngine;

public delegate void ImpactHandler();

public class Projectile : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;

    const float BottomY = 0.0f;

    public event ImpactHandler onImpact;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= BottomY)
        {
            Impact(transform.position, transform.rotation);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Impact(pos, rot);
    }

    void Impact(Vector3 position, Quaternion rotation)
    {
        if (onImpact != null)
        {
            onImpact();
        }

        Instantiate(explosionPrefab, position, rotation);
        Destroy(gameObject);
    }
}
