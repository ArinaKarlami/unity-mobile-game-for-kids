using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Max Health")]
    [Range(1, 10)]
    [SerializeField] private int maxHealth = 3;

    private int currentHealth = -1;

    private PlayerHealthUI healthUI;
    private CircleCollider2D collider2D;

    private void Start()
    {
        healthUI = GetComponent<PlayerHealthUI>();
        collider2D = GetComponent<CircleCollider2D>();

        if (PlayerPrefs.HasKey("health"))
        {
            int health_ = PlayerPrefs.GetInt("health");
            currentHealth = health_ <= maxHealth ? health_ : maxHealth;
        }
        else
        {
            currentHealth = maxHealth;
        }

        healthUI.InitUI(maxHealth, currentHealth);
    }

    public void Damage(int damage)
    {
        ChangeHealth(- Mathf.Abs(damage));
    }

    public void Add(int add)
    {
        ChangeHealth(Mathf.Abs(add));
    }

    private void ChangeHealth(int changeValue)
    {
        currentHealth = (currentHealth + changeValue) <= maxHealth ?
            currentHealth + changeValue : maxHealth;

        healthUI.UpdateUI(currentHealth);

        if (currentHealth <= 0)
        {
            PlayerPrefs.SetInt("health", maxHealth);
            collider2D.isTrigger = true;
        }
        else
        {
            PlayerPrefs.SetInt("health", currentHealth);
        }
    }
}
