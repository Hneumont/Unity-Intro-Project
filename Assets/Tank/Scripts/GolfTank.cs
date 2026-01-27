using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
// NOTE: tank should have some way to control 'putt power'
// putt power will increase recoil and should cause the bullet shot to be faster

public class GolfTank : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 90.0f; // rotation in degrees per second

    [SerializeField] GameObject ammo;
    [SerializeField] GameObject muzzle;
    [SerializeField] float recoil = .2f;

    InputAction moveAction;
    InputAction attackAction;
    InputAction lookAction;

    void Start()
    {
        moveAction =  InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
        attackAction =  InputSystem.actions.FindAction("Attack");
        attackAction.started += ctx => onPutt();
    }

    void Update()
    {
        // direction (forward/backward movement)
        //float direction = 0.0f;
        float direction = moveAction.ReadValue<Vector2>().y;
        //if (Keyboard.current.wKey.isPressed) direction = +1.0f;
        //if (Keyboard.current.sKey.isPressed) direction = -1.0f;

        // rotation (left/right)
        //float rotation = 0.0f;
        float rotation = moveAction.ReadValue<Vector2>().x;
        //if (Keyboard.current.aKey.isPressed) rotation = -1.0f;
        //if (Keyboard.current.dKey.isPressed) rotation = +1.0f;

        // rotate the tank, around the up axis (y-axis)
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);

        // check if "Fire" key is pressed, if so instantiate the ammo (rocket)
        // ammo is instantiate at the muzzle position and rotation
        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //if (attackAction.wasPressedThisFrame())
        //{
        //    Rigidbody rb = GetComponent<Rigidbody>();
        //    rb.AddRelativeForce(Vector3.forward * -recoil, ForceMode.Impulse);
        //    Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
        //}
    }

    void onPutt() //fire a bullet, tank moves opposite direction
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * -recoil, ForceMode.Impulse);
        Instantiate(ammo, muzzle.transform.position, muzzle.transform.rotation);
    }
}
