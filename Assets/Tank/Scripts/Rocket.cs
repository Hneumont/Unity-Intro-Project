using UnityEngine;
using UnityEngine.InputSystem;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] float speed = 1.0f;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddRelativeForce(Vector3.up * speed, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
        print("COLLIDED WITH"+other.gameObject.name);
    }
}
