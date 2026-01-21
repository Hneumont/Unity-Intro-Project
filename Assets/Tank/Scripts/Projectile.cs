using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : Ammo
{
    [SerializeField] GameObject effect;
    [SerializeField] float speed = 1.0f;
    [SerializeField] public Rigidbody parent;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision other) {
        // check if hit object has health compononet
        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
           // if (other.gameObject == parent) break;
            //deal damage to hit
            health.OnDamage(damage);
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
