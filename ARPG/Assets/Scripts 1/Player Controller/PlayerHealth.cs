using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public Text currentHealthLabel;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateGUI();
    }
    public void UpdateGUI()
    {
        currentHealthLabel.text = currentHealth.ToString();
    }

    public void HealthChange(int amount)
    {
        currentHealth += amount;
        Debug.Log(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateGUI();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
    }
}