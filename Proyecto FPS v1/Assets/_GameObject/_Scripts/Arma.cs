using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform spawmPoint;
    [SerializeField] float force = 100;
    public void Disparar() {
        GameObject proyectil = Instantiate(prefabProyectil, spawmPoint.position, spawmPoint.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(spawmPoint.forward * force);
    }

    
}
