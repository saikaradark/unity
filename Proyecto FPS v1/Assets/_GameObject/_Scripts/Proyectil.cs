using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField] int danyo = 20;
    [SerializeField] GameObject prefabImpacto;
    private void OnCollisionEnter(Collision collision) {
        //collision.gameobject me proporciona el objeto con el que se ha colisionado
        if (collision.gameObject.CompareTag("Enemigo")) {
            //es un enemigo
            collision.gameObject.GetComponent<Enemigo>().RecibirDanyo(danyo);
            Destroy(gameObject);
        }
    }
}

