using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject prefabEnemigo;
    [SerializeField] int timebetweenspawm = 5;
    void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0, timebetweenspawm);
    }

    // Update is called once per frame
    private void GenerarEnemigo()
    {
        Instantiate(prefabEnemigo, transform);
    }
}
