using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    public Image HealthBarİmage;


    public void HealthBarCheck(float Health, float MaxHealth) 
    {
        HealthBarİmage.fillAmount = Health / MaxHealth;
    }

}
