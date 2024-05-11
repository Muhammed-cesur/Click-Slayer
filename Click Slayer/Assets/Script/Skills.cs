using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Skills : MonoBehaviour
{

    public Enemy _enemy;
    public GameObject ClickButton;
    public float ClickIncreaseCoin;
    public float ClickDamage;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        ClickButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        ClickDamageIncreaseCheck();
        
    }
    private void ClickDamageIncreaseCheck()
    {
        if (_enemy.Coins>= ClickIncreaseCoin) 
        {
            ClickButton.SetActive(true);
            
        }
        else
        {
            ClickButton.SetActive(false);
        }
    }
    public void ClickDamageIncrease()
    {

        _enemy.Coins -= ClickIncreaseCoin;
        ClickIncreaseCoin *= 2;
        ClickDamage ++;
        _enemy._damage = ClickDamage;

    }
}
