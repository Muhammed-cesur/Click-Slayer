using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    public float Health;
    public float MaxHealth;
    public float _damage;
    public GameObject _enemy;

    private HealthSystem _healthSystem;
   
    private Animator _anim;
    void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();

        _anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage(_damage);
        }

    }

    private void TakeDamage(float Damage) 
    {
       
        Health -= Damage;
        _anim.SetTrigger("Hit");
        _healthSystem.HealthBarCheck(Health, MaxHealth);


        if (Health <= 0)
        {
            _anim.SetTrigger("Die");
            Invoke(nameof(DestroyEnemy), 1.5f);
            Debug.Log("Hasarrrr");
        }
    }


    private void DestroyEnemy() 
    {
        Destroy(gameObject);
        Instantiate(_enemy);
    }
}
