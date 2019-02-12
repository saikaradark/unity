using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRandom : MonoBehaviour
{
    [SerializeField] GameObject[] prefabEnemigo;
    [SerializeField] int timebetweenspawm = 5;
    void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0, timebetweenspawm);
    }

    // Update is called once per frame
    private void GenerarEnemigo()
    {
        int numeroEnemigos = prefabEnemigo.Length;
        int indiceenemigoAleatorio = Random.Range(0, numeroEnemigos);
        Instantiate(prefabEnemigo[indiceenemigoAleatorio], transform);







       /* float tipoEnemigo = Random.Range(0f, 1f);
        if (tipoEnemigo < 0.5f)
        {
            Instantiate(prefabEnemigo[1], transform);
        }
        else
        {
            Instantiate(prefabEnemigo[0], transform);
        }
        */
       // Instantiate(prefabEnemigo, transform);
    }
}
