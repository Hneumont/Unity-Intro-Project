using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{

    bool open = false;
    Coroutine coroutine = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //StartCoroutine(TimerCR());
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            open = true;
        }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
            else
            {
                coroutine = StartCoroutine("TimerCR");
            }
        }
    }

    IEnumerator TimerCR()//float delay
    {
        yield return new WaitUntil(IsOpen);//() => open);
        print("open");

        print("hello :)");
        yield return new WaitForSeconds(1.0f);
        print("world");
        yield return new WaitForSeconds(1.0f);
        print("goodbye :(");
        yield return new WaitForSeconds(5.0f);
        while (true)
        {
            print("repeat");
            yield return new WaitForSeconds(0.5f);
        }
    }

    bool IsOpen() => open;
}
