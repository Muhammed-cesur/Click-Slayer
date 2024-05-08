using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public Image HealthBar›mage;


    public void HealthBarCheck(float Health, float MaxHealth) 
    {
        HealthBar›mage.fillAmount = Health / MaxHealth;
    }

}
