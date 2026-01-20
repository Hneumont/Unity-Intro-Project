using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 10;
    [SerializeField] GameObject hitEffect;
    [SerializeField] GameObject destroyEffect;
    public float CurrentHealth
    {
        get { return health; }
        set { health = Mathf.Clamp(value, 0, maxHealth); }
    }
    public float CurrentHealthPercentage
    {
        get { return CurrentHealth / maxHealth; }
    }
    bool destroyed = false;

    float health = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = maxHealth;

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
            TankGameManager.Instance.Score += 100;
            if (destroyEffect != null) Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void OnHeal(float amount)
    {
        CurrentHealth += amount;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
