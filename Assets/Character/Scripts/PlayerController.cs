using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Actor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform view;

    Actor actor;

    iMovable movable;
    iAttackable attackable;
    iJumpable jumpable;
    iSprintable sprintable;

    private void Awake()
    {
        actor = GetComponent<Actor>();
        view ??= Camera.main.transform;

        movable = actor as iMovable;
        attackable = actor as iAttackable;
        jumpable = actor as iJumpable;
        sprintable = actor as iSprintable;
    }

    void OnJump()
    {
        jumpable?.Jump();
    }

    void OnAttack()
    {
        attackable?.Attack();
    }

    void onSprint(InputValue value)
    {
        if (value.isPressed) sprintable?.StartSprint();
        else sprintable?.StopSprint();
    }

    void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        Vector3 moveDirection = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up) * new Vector3(inputDir.x, 0, inputDir.y);
        movable?.Move(moveDirection);
    }
}
