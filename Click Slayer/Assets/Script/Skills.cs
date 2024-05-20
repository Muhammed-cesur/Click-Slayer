using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using TMPro;


public class Skills : MonoBehaviour
{

    public Enemy _enemy;

    [Header("Damages & Chance")]
    public float ClickDamage;
    public int CriticChance;
    public float CriticIncrease;
    public float CoinIncrease;


    [Header("Levels")]
    public float ClickDamageLevel;
    public float CriticChanceLevel;
    public float CriticDamageLevel;
    public float CoinIncreaseLevel;

    public TextMeshProUGUI _clickDamageLevel;
    public TextMeshProUGUI _criticChanceLevel;
    public TextMeshProUGUI _criticDamageLevel;
    public TextMeshProUGUI _coinIncreaseLevel;




    [Header("Buttons")]
    public GameObject ClickButton;
    public GameObject CriticChanceButton;
    public GameObject CriticDamageIncreaseButton;
    public GameObject CoinIncreaseButton;


    [Header("Coins")]  
    public float ClickIncreaseCoin;
    public float CriticDamageChanceCoin;
    public float CriticDamageIncreaseCoin;
    public float CoinIncreaseCoin;


    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        StartButtonManager();

    }

    // Update is called once per frame
    void Update()
    {
        CoinAndLevelCheck();
        CriticDamage();
        Cartcurt();
    }
    
    private void CoinAndLevelCheck()
    {
        ToStringManager();
        CoinManager();
        ButtonLevelfalse();
    }

    #region ClickDamage
    public void ClickDamageIncrease()
    {

        _enemy.Coins -= ClickIncreaseCoin;
        ClickIncreaseCoin ++;
        ClickDamage ++;
        ClickDamageLevel++;
        if (ClickDamageLevel>=11)
        {
            ClickDamage += 2;
        }
        _enemy._damage = ClickDamage;
    }
    #endregion

    #region CriticDamageChance
    public void CriticDamageChance()
    {
        CriticDamageChanceCoin ++;

        if (_enemy.Coins>=CriticDamageChanceCoin)
        {
            _enemy.Coins-=CriticDamageChanceCoin;
            CriticChance--;
            CriticChanceLevel++;

        }
    }

        private void CriticDamageChanceIncrease()
    {
        CriticDamageIncreaseCoin ++;
        _enemy.Coins -= CriticDamageIncreaseCoin;
        CriticIncrease += 1.1f;
        CriticDamageLevel++;
        if (CriticDamageLevel>=11)
        {
            CriticIncrease+=1.25f;
        }
        else if (CriticDamageLevel>=26)
        {
            CriticIncrease+=1.5f;
        }
    }
    private void CriticDamage()
    {
       
        int RandomCritic = Random.Range(0, CriticChance);
        
        if (Input.GetMouseButtonDown(0) &RandomCritic == CriticChance - 1) 
        {
            Invoke(nameof(delay), 1f);
            _enemy._damage = CriticIncrease;  
        }
    }
    private void delay()
    {
        if (_enemy._damage > ClickDamage)
        {
            _enemy._damage = ClickDamage;
        }
    }

    #endregion

    #region Coin Increase

    public void CoinIncreaseMngr()
    {


        _enemy.Coins -= CoinIncreaseCoin;
        CoinIncreaseCoin ++;
        CoinIncrease ++;

        CoinIncreaseLevel++;
    }
    private void Cartcurt()
    {
        if (_enemy.DeadCoins==true)
        {
            _enemy.Coins = CoinIncrease;
            Debug.Log("Altýn : " + CoinIncrease);
        }
    }

    #endregion


    private void CoinManager()
    {
        if (_enemy.Coins >= ClickIncreaseCoin)
        {
            ClickButton.SetActive(true);

        }
        else
        {
            ClickButton.SetActive(false);
        }

        if (_enemy.Coins >= CriticDamageChanceCoin)
        {
            CriticChanceButton.SetActive(true);

        }
        else
        {
            CriticChanceButton.SetActive(false);
        }

        if (_enemy.Coins >= CriticDamageIncreaseCoin)
        {
            CriticDamageIncreaseButton.SetActive(true);
        }
        else
        {
            CriticDamageIncreaseButton.SetActive(false);
        }

        if (_enemy.Coins>=CoinIncreaseCoin)
        {
            CoinIncreaseButton.SetActive(true);
        }
        else 
        {
            CoinIncreaseButton.SetActive(false);
        }
    }
    private void ButtonLevelfalse()
    {
        if (ClickDamageLevel == 25)
        {
            ClickButton.SetActive(false);
        }
        if (CriticDamageLevel==50)
        {
            CriticDamageIncreaseButton.SetActive(false);
        }
        if (CriticChanceLevel==50)
        {
            CriticChanceButton.SetActive(false);
        }
        if (CoinIncreaseLevel==25)
        {
            CoinIncreaseButton.SetActive(false);
        }

    }
    private void ToStringManager()
    {
        _clickDamageLevel.text = ClickDamageLevel.ToString();
        _criticChanceLevel.text = CriticChanceLevel.ToString();
        _criticDamageLevel.text = CriticDamageLevel.ToString();
        _coinIncreaseLevel.text = CoinIncreaseLevel.ToString();
    }
    private void StartButtonManager()
    {
        ClickButton.SetActive(false);
        CriticChanceButton.SetActive(false);
        CriticDamageIncreaseButton.SetActive(false);
        CoinIncreaseButton.SetActive(false);
    }
}
