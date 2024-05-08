using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject _SpawnObject;
    // public Transform _SpawnTransform;

    private void Update()
    {
       
    }
    public void EnemyRespawn()
    {

        if (_SpawnObject != null)
        {
            Instantiate(_SpawnObject);
        }
        else
        {
            Debug.LogError("SpawnObject is not set in the SpawnManager!");
        }
    }
}
