using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptableObjectExample : MonoBehaviour
{

    [SerializeField] IntData score;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.jKey.wasPressedThisFrame)
        {
            score.value += 100;
        }
    }
}
