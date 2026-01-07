using UnityEngine;
using UnityEngine.InputSystem;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnCooldown = 10.0f;
    [SerializeField] GameObject spawnObject;

    private void Awake(){

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame){
            Instantiate(spawnObject, transform.position, transform.rotation);
        }
    }
}
