using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor;


public class Skills : MonoBehaviour
{

    private Enemy _enemy;
    private Hero _hero;
    


    [Header("Damages & Chance")]
    public float ClickDamage;
    public int CriticChance;
    public float CriticIncrease;
    public float CoinIncrease;
    public float Hero1damage;
    public float Hero2damage;




    [Header("Levels")]
    public float ClickDamageLevel;
    public float CriticChanceLevel;
    public float CriticDamageLevel;
    public float CoinIncreaseLevel;
    public float Hero1Level;
    public float Hero2Level;
    public float Hero1damageLevel;
    public float Hero2damageLevel;
    public float HeroDelayLevel;



    public TextMeshProUGUI _clickDamageLevel;
    public TextMeshProUGUI _criticChanceLevel;
    public TextMeshProUGUI _criticDamageLevel;
    public TextMeshProUGUI _coinIncreaseLevel;
    public TextMeshProUGUI _hero1Level;
    public TextMeshProUGUI _hero2Level;
    public TextMeshProUGUI _hero1damageLevel;
    public TextMeshProUGUI _hero2damageLevel;
    public TextMeshProUGUI _heroDelayLevel;






    [Header("Buttons")]
    public GameObject ClickButton;
    public GameObject CriticChanceButton;
    public GameObject CriticDamageIncreaseButton;
    public GameObject CoinIncreaseButton;
    public GameObject Hero1Button;
    public GameObject Hero2Button;
    public GameObject Hero1damageButton;
    public GameObject Hero2damageButton;
    public GameObject HeroDelayButton;



    [Header("Coins")]  
    public float ClickIncreaseCoin;
    public float CriticDamageChanceCoin;
    public float CriticDamageIncreaseCoin;
    public float CoinIncreaseCoin;
    public float Hero1Coin;
    public float Hero2Coin;
    public float Hero1damageCoin;
    public float Hero2damageCoin;
    public float HeroDelayCoin;


    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _hero = GetComponent<Hero>();
        StartButtonManager();
    }

// Update is called once per frame
void Update()
    {
        CoinAndLevelCheck();
        CriticDamage();
       
        HeroAttack();
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
            Invoke(nameof(Delay), 1f);
            _enemy._damage = CriticIncrease;  
        }
    }
    private void Delay()
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



    #endregion

    #region Hero
    public void Hero1()
    {
        _enemy.Coins -= Hero1Coin;
        Hero1Coin ++;
        Hero1Level ++;
        _hero.MaleHero.SetActive(true);
       
        _hero.Malehero = true;
        _hero.Attacked=true;


    }
    public void Hero2()
    {
       
        _enemy.Coins -= Hero2Coin;
        Hero2Coin++;
        Hero2Level++;

        _hero.Femalehero=true;
        _hero.Attacked=true;
    }

    private void HeroAttack() 
    {
       
        if (Hero1Level==1 || Hero2Level==1 )
        {
            if (_hero.Attacked == true)
            {
                _hero.HeroAttack();
            }
            if (_hero.Attacked==false && Input.GetMouseButtonDown(0))
            {
                _hero.Attacked = true;
            }
           
        }
    }
    #endregion

    #region HeroDamage

    public void Hero1Damage()
    {
        _enemy.Coins-= Hero1damageCoin;
        Hero1damageCoin ++;
        Hero1damageLevel ++;
        Hero1damage += 25;
    }
    public void Hero2Damage()
    {
        _enemy.Coins -= Hero2damageCoin;
        Hero2damageCoin++;
        Hero2damageLevel++;
        Hero2damage += 25;
    }
    #endregion

    #region HeroDelay
    public void HeroDelay()
    {
        _enemy.Coins-=HeroDelayCoin;
        HeroDelayCoin ++;
        HeroDelayLevel++;
        _hero.AttackDelay--;
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
        if (_enemy.Coins>=Hero1Coin)
        {
            Hero1Button.SetActive(true);
        }
        else
        {
            Hero1Button.SetActive (false);
        }

        if (_enemy.Coins >= Hero2Coin)
        {
            Hero2Button.SetActive(true);
        }
        else
        {
            Hero2Button.SetActive(false);
        }

        if (_enemy.Coins>=Hero1damageCoin)
        {
            Hero1damageButton.SetActive(true);
        }
        else
        {
            Hero1damageButton.SetActive(false);
        }

        if (_enemy.Coins >= Hero2damageCoin)
        {
            Hero2damageButton.SetActive(true);
        }
        else
        {
            Hero2damageButton.SetActive(false);
        }
        if (_enemy.Coins>=HeroDelayCoin)
        {
            HeroDelayButton.SetActive(true);
        }
        else
        {
            HeroDelayButton.SetActive (false);
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
        if (Hero1Level==1)
        {
            Hero1Button.SetActive(false);
        }
        if (Hero2Level == 1)
        {
            Hero2Button.SetActive(false);
        }
        if (Hero1damageLevel==10)
        {
            Hero1damageButton.SetActive(false);
        }
        if (Hero2damageLevel == 10)
        {
            Hero2damageButton.SetActive(false);
        }
        if (HeroDelayLevel==10)
        {
            HeroDelayButton.SetActive(false);
        }
    }
    private void ToStringManager()
    {
        _clickDamageLevel.text = ClickDamageLevel.ToString();
        _criticChanceLevel.text = CriticChanceLevel.ToString();
        _criticDamageLevel.text = CriticDamageLevel.ToString();
        _coinIncreaseLevel.text = CoinIncreaseLevel.ToString();
        _hero1Level.text = Hero1Level.ToString();
        _hero2Level.text = Hero2Level.ToString();
        _hero1damageLevel.text=Hero1damageLevel.ToString();
        _hero2damageLevel.text = Hero2damageLevel.ToString();
        _heroDelayLevel.text = HeroDelayLevel.ToString();
    }
    private void StartButtonManager()
    {
        ClickButton.SetActive(false);
        CriticChanceButton.SetActive(false);
        CriticDamageIncreaseButton.SetActive(false);
        CoinIncreaseButton.SetActive(false);
        Hero1Button.SetActive(false);
        Hero2Button.SetActive(false);
        Hero1damageButton.SetActive(false);
        Hero2damageButton.SetActive (false);
        HeroDelayButton.SetActive(false);
    }

}
