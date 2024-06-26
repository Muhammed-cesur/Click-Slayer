using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class Enemy : MonoBehaviour
{


    public float _Health;
    public float _MaxHealth;
    public float _damage;
    public float _EnemyDie;



    public GameObject _enemy;
    public GameObject _enemy2;
    public GameObject _enemy3;
    public TextMeshProUGUI _enemyText;
    public ParticleSystem Coinparticle;

    public TextMeshProUGUI _coinsText;
    public float Coins;


    public bool DeadCoins;
    public bool CanTakeDamage;

    private HealthSystem _healthSystem;
    Skills _skill;
    
   
    private Animator _anim;
    void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _skill = GetComponent<Skills>();
        _Health = _MaxHealth;
        _healthSystem.HealthBarİmage.fillAmount=_MaxHealth;
        _anim = GetComponent<Animator>();
        CanTakeDamage = true;
        DeadCoins = false;
    }
    private void Update()
    {
        Mathf.FloorToInt(_Health);
        Mathf.FloorToInt(_MaxHealth);

        if (Input.GetMouseButtonDown(0) & CanTakeDamage)
        {
            TakeDamage(_damage);
        }
        _enemyText.text = _Health.ToString();
        _coinsText.text = Coins.ToString();



    }

    public void TakeDamage(float Damage) 
    {
       
        _Health -= Damage;
        _anim.SetTrigger("Hit");
        _healthSystem.HealthBarCheck(_Health, _MaxHealth);


        if (_Health <= 0)
        {
            CanTakeDamage = false;
            _anim.SetTrigger("Die");
            Invoke(nameof(DestroyEnemy), 1.5f);
            Coinparticle.Play();
            DeadCoins = true;
            _EnemyDie++;
            Coins++;
            if (DeadCoins == true && _skill.CoinIncreaseLevel >= 1)
            {
                Coins += _skill.CoinIncrease;
            }

        }
        else
        {
            CanTakeDamage = true;
            DeadCoins = false;
        }
    }

    private void DestroyEnemy() 
    {

        _Health *= 1.25f;
        _MaxHealth*= 1.25f;

        int RandonEnemy= Random.Range(0, 3);
       // Instantiate(_enemy, _enemy.transform.position, _enemy.transform.rotation);
        if (RandonEnemy==0) { Instantiate(_enemy ,transform.position, transform.rotation); }
        if (RandonEnemy == 1) { Instantiate(_enemy2, transform.position, transform.rotation); }
        if (RandonEnemy == 2) { Instantiate(_enemy3, transform.position, transform.rotation); }

        Destroy(gameObject);
    }


}
