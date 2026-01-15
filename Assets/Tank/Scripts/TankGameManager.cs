using System.Diagnostics.Contracts;
using TMPro;
//using UnityEngine
using UnityEngine;

public class TankGameManager : MonoBehaviour
{
    [SerializeField] GameObject titlePanel;
    [SerializeField] TMP_Text scoreText;

    public int score = 0;

    public void onGameStart()
    {
        titlePanel.active = false;
        //TimeScale = 1.0f
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
