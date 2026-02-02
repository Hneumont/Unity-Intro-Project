using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]  float rotationSpeed = 45.0f;
    [SerializeField]  float fireRate = 1.0f;
    [SerializeField]  Ammo ammo;
    [SerializeField] Transform muzzle;

    float fireTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (fireTimer <= 0)
        {
            fireTimer += fireRate;
            Ammo bullet;
            bullet = Instantiate(ammo, muzzle.position, muzzle.rotation);
            bullet.tag = "Enemy";
        }
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
