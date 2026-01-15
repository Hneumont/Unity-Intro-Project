using UnityEngine;

public class OneTimeFX : MonoBehaviour
{
    [SerializeField] private float loops;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
         {
             Destroy(this.gameObject, GetComponent<ParticleSystem>().main.duration * loops);
         }
}
