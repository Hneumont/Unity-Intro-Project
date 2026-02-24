using UnityEngine;
using UnityEngine.Events;

public class EventsRecieverExample : MonoBehaviour
{
    public EventSO startEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //UnityEvent events = FindFirstObjectByType<EventsExample>;
       // events.gameAction += OnGameAction;
    }

    private void OnEnable()
    {
        startEvent.Subscribe(OnGameStart);
    }
    private void OnDisable()
    {
        startEvent.Unsubscribe(OnGameStart);
    }

    public void OnGameStart()
    {
        print("Game started!");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGameEvent()
    {
        print("Game Evented");
    }
    public void OnGameEvent(string str)
    {
        print(str);
    }
    public void OnGameAction()
    {
        print("Game Actioned!");
    }

}
