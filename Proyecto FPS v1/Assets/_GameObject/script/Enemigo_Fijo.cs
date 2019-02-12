using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Fijo : Enemigo {
    public float fuerzaDisparo = 10f;
    public GameObject prefabBalas;
    public Transform spawmPoint;
    public float cadenciaDisparo;
    public Transform ejeRotacion;

    private void Disparar() {
        GameObject bala = Instantiate(prefabBalas, spawmPoint.position, spawmPoint.rotation);
        bala.GetComponent<Rigidbody>().AddForce(spawmPoint.forward * fuerzaDisparo);
    }

    enum Estado { Idle, Attack, Reload};
     private Estado estado = Estado.Idle;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            estado = Estado.Attack;
            InvokeRepeating("Disparar", 0, cadenciaDisparo);
        
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            estado = Estado.Idle;
            CancelInvoke();
        }
    }
    private void Update() {
        if (estado == Estado.Attack) {
            ejeRotacion.LookAt(transformPlayer);
            Disparar();
        }
    }
   
}
