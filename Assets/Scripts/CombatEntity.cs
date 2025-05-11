using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatEntity : MonoBehaviour
{
    public float CurrentHealth, MaxHealth;
    public Image HealthBarFill;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBarFill.fillAmount = CurrentHealth / MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0f)
        {
            CurrentHealth = 0f;
            Death();
        }
    }

    public void Death()
    {

    }
}
