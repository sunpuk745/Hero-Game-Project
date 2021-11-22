using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(true);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);

    }

}
