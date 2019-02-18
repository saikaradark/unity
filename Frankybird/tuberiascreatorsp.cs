using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuberiascreatorsp : MonoBehaviour{
    [SerializeField] GameObject TuberiasPrefabs;
    [SerializeField] float tiempoEntreTuberias = 2.2f;

    void Start() {
        InvokeRepeating("Creartuberia", 0, tiempoEntreTuberias);
    }
    void Update() {

    }
    private void Creartuberia() {
            Instantiate(TuberiasPrefabs, transform);
    }
    
}
