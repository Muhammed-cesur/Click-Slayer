using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieCounter : MonoBehaviour
{

    public GameObject NatureButton;
    public GameObject DungeonButton;
    public GameObject FantasyButton;


    private Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
       
        DungeonButton.SetActive(false);
        FantasyButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDieCntr();
    }

   private void EnemyDieCntr() 
    {
       if (_enemy._EnemyDie>=10) 
        {
            FantasyButton.SetActive(true);

        }
        if (_enemy._EnemyDie >= 25)
        {
            DungeonButton.SetActive(true);
        }
    }
    


}
