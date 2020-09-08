using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    private void Awake()
    {
        slider.value = 100;
    }
    public void setHealth(int health) {
        slider.value = health;
    }
}
