using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class HealthController
{
    public Image healthImage;
    public float currentHealth;
    public float maxHealth;

    public void LoseHealth(float damage) {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            UpdateHealthImage();
        }
    }

    public void GainHealth() {
        UpdateHealthImage();
    }

    void UpdateHealthImage() {
        healthImage.fillAmount = currentHealth / maxHealth;
    }

}
