using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankGameManager : MonoBehaviour
{
    [SerializeField] GameObject titlePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] bool debug = false;

    static TankGameManager instance;
    public static TankGameManager Instance { get {if (instance == null) instance = FindFirstObjectByType<TankGameManager>();return instance;}}

    public int Score { get; set; } = 10000;

    public void onGameStart()
    {
        winPanel.SetActive(false); //not needed, here for redundancy
        titlePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void onGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnGameWin()
    {
        Time.timeScale = 0.0f;
        winPanel.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = (debug) ? 1.0f : 0.0f;
        titlePanel.SetActive(!debug);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Score.ToString();
    }
}
