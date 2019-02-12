using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajadesalud : MonoBehaviour{

    public int cantidadSalud = 50;
    [SerializeField] private float velocidadGiro = 100f;

    void Update(){
        Rotar();
   
    }

    private void Rotar() {
        transform.Rotate(new Vector3(0, Time.deltaTime * velocidadGiro, 0));


    }
    private void OnTriggerEnter(Collider other) {
        print("Ha entrado");
        /*
         * 1. la caja de salud a sido atravesada por el player?
         * 
         * 
         */
         if (other.gameObject.CompareTag("Player")) {
            bool atope = other.gameObject.GetComponent<Player>().IncrementarSalud(cantidadSalud);
            if (atope == false) {
                Destroy(this.gameObject);

            }


        }





















    }
}
