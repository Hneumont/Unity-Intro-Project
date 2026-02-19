using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPrefsExample : MonoBehaviour
{
    int highscore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        print($"HighScore: {highscore}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            OnSetHighScore(500);
        }
    }

    void OnSetHighScore(int score)
    {
        highscore = score;
        PlayerPrefs.SetInt("HighScore", highscore);
    }
}
