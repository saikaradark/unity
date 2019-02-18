using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuberiascreatorsp : MonoBehaviour
{
    [SerializeField] GameObject tuberiasPrefab;
    [SerializeField] float tiempoEntreTuberias = 2.2f;
    GameObject gestordeljuego;//Atencion
    void Start() {
        gestordeljuego = GameObject.Find("gestordeljuego");
        InvokeRepeating("CrearTuberia", 0, tiempoEntreTuberias);
    }
    void Update() {

    }
    private void CrearTuberia() {
        if (gestordeljuego.GetComponent<gestordeljuego>().GetJugando() == true) {
            Instantiate(tuberiasPrefab, transform);
        }
    }
}