using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMnager : MonoBehaviour
{
    public GameObject Area1;
    public GameObject Area2;
    public GameObject Area3;
  //  public GameObject Area4;

    // Start is called before the first frame update

    public void NatureButton1()
    {
        
        /////////////////////////////////////////
        Area1.SetActive(true);
        Area2.SetActive(false);
        Area3.SetActive(false);
       // Area4.SetActive(false);
    }
    public void DungeonButton1()
    {
        /////////////////////////////////////////
        Area1.SetActive(false);
        Area2.SetActive(true);
        Area3.SetActive(false);
        //Area4.SetActive(false);
    }
    public void FantasyButton1()
    {
        /////////////////////////////////////////
        Area1.SetActive(false);
        Area2.SetActive(false);
        Area3.SetActive(true);
       // Area4.SetActive(false);
    }

    public void PokemonButton1()
    {
        /////////////////////////////////////////
        Area1.SetActive(false);
        Area2.SetActive(false);
        Area3.SetActive(false);
      // Area4.SetActive(true);
    }
}
