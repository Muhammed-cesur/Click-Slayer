using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using TMPro;


public class Enemy : MonoBehaviour
{


    public float _Health;
    public float _MaxHealth;
    public float _damage;
    public GameObject _enemy;
    public TextMeshProUGUI _enemyText;

    private bool CanTakeDamage;
    private HealthSystem _healthSystem;
    
   
    private Animator _anim;
    void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _Health = _MaxHealth;
        _healthSystem.HealthBar›mage.fillAmount=_MaxHealth;
        _anim = GetComponent<Animator>();
        CanTakeDamage = true;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) & CanTakeDamage)
        {
            TakeDamage(_damage);
        }
        _enemyText.text = _Health.ToString();

    }

    private void TakeDamage(float Damage) 
    {
       
        _Health -= Damage;
        _anim.SetTrigger("Hit");
        _healthSystem.HealthBarCheck(_Health, _MaxHealth);


        if (_Health <= 0)
        {
            CanTakeDamage = false;
            _anim.SetTrigger("Die");
            Invoke(nameof(DestroyEnemy), 1.5f);
                
        }
        else
        {
            CanTakeDamage = true;
        }
    }


    private void DestroyEnemy() 
    {
        Instantiate(_enemy);
        Destroy(gameObject);
        

    }


}
