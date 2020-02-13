using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDDisplay : MonoBehaviour
{
    public Image hpBar;
    public Image damageDisplay;
    public static HUDDisplay instance;
    private float lifeTime = 1f;
    public float damageTimeForFade = 1f;

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

    public void playerTookDamage()
    {
        damageDisplay.gameObject.SetActive(true);
        lifeTime = damageTimeForFade;

    }

     void FixedUpdate()
    {
        
        lifeTime -= Time.deltaTime;
        var alpha = 1 - lifeTime/damageTimeForFade;
        damageDisplay.color = Color.Lerp(Color.white, new Color(1,1,1,0), alpha);

    }
}
