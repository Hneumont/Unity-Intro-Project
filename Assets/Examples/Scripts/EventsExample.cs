using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EventsExample : MonoBehaviour
{
    [SerializeField] UnityEvent gameEvent;
    [SerializeField] UnityEvent<string> gameEventString;

    [SerializeField] UnityAction gameAction;
    [SerializeField] EventSO startEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            gameEvent?.Invoke();
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            gameEventString?.Invoke("stringyyyy");
        }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            gameAction?.Invoke();
        }
        //if (Keyboard.current.lKey.wasPressedThisFrame)
        //{
        //    startEvent.RaiseEvent();
        //}
    }
}
