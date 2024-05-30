using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Hero : MonoBehaviour
{
    Skills _skills;
    Enemy _enemy;
    public GameObject MaleHero;
    public GameObject FemaleHero;


    public Animator _fAnim;
    public Animator _mAnim;

    public float AttackDelay;
    public bool Attacked;
    public bool LvlUp;
    public bool Malehero;
    public bool Femalehero;



    // Start is called before the first frame update
    void Start()
    {
        MaleHero.SetActive(false);
        FemaleHero.SetActive(false);
        Attacked = false;
        LvlUp = false;
        _skills=GetComponent<Skills>();
        _enemy=GetComponent<Enemy>();


    }


    public void HeroAttack()
    {
        Attacked = true;
        if (Attacked==true)
        {
            StartCoroutine(AttckDelay());
            Debug.Log("Attack true");
        }

        if (Malehero==true) 
        {
        MaleHero.SetActive (true);
        }
        else { MaleHero.SetActive (false);}

        if (Femalehero == true)
        {
            FemaleHero.SetActive(true);
        }
        else { FemaleHero.SetActive(false); }

        _fAnim.SetBool("Attack", false);
        _mAnim.SetBool("Attack", false);

    }

    public IEnumerator AttckDelay()
    {
        Debug.Log("Attack False");
        Attacked = false;
        yield return new WaitForSecondsRealtime(AttackDelay);
        if (Malehero==true)
        {
            _enemy.TakeDamage(_skills.Hero1damage);
            _mAnim.SetBool("Attack", true);
        }
        if (Femalehero==true)
        {
            _enemy.TakeDamage(_skills.Hero2damage);
            _fAnim.SetBool("Attack", true);

        }
        
        Attacked = true; 
    }


}
