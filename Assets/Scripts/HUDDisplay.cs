using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDisplay : MonoBehaviour
{
    public Image hpBar;
    public static HUDDisplay instance;

    private void Awake() 
    {
        instance = this;
    }
    public void updateHPBar(float currentHealth, float maxHealth)
    {
        var percentage = currentHealth/maxHealth;
        hpBar.fillAmount = percentage;

        hpBar.color = Color.Lerp(Color.red, Color.green, percentage);

    }

}
