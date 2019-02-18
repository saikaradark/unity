using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuberiasScript : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] int timeToDestroy = 5;
    GameObject gdj;   
        
    void Start(){
        transform.Translate(0, Random.Range(-2, 2), 0);
        gdj = GameObject.Find("gestordeljuego");
        Destroy(this.gameObject, timeToDestroy);
    }

    void Update() {
        if (gdj.GetComponent<gestordeljuego>().GetJugando() == true) {
           transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}

