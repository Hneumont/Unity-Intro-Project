using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

using CGL.DesignPatterns;
public class SceneExample : MonoBehaviour
{
    [SerializeField] string sceneName01;
    [SerializeField] string sceneName02;
    [SerializeField] string sceneName03;

    void OnValidate()
    {
        if(string.IsNullOrEmpty(sceneName01)) {Debug.LogError("no scene name");}
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(sceneName01);
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(sceneName02); //LoadSceneMode.Additive
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName03));
        }
    }

    IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            float progress = asyncLoad.progress;
            Debug.unityLogger.Log(progress);
        }

        yield return null;
    }
    
    
}
