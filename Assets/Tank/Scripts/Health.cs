using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;
    [SerializeField] public float CurrentHealth = -1.0f; // { get; set; }
    bool destroyed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (CurrentHealth == -1){
            CurrentHealth = maxHealth;
        }
    }

    public void OnDamage(float damage)
    {
        if (destroyed) return;
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) destroyed = true;

        if (!destroyed && hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        if (destroyed)
        {
            if (destroyEffect != null) Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
