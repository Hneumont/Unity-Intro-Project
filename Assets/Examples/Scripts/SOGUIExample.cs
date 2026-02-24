using TMPro;
using UnityEngine;

public class SOGUIExample : MonoBehaviour
{
    [SerializeField] IntData score;
    [SerializeField] TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = $"Score: {score.value.ToString("0000")}";
    }
}
