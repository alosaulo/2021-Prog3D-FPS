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

    public void GainHealth(float gain) {
        /*currentHealth = Mathf.Clamp(currentHealth + gain, 0, maxHealth);*/
        if (currentHealth + gain > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else {
            currentHealth += gain;
        }
        UpdateHealthImage();
    }

    void UpdateHealthImage() {
        healthImage.fillAmount = currentHealth / maxHealth;
    }

    public bool isHealthFull() {
        if (currentHealth >= maxHealth)
            return true;
        else
            return false;
    }

}
