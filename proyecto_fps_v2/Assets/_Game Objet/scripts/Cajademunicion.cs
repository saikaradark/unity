using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajademunicion : MonoBehaviour
{
    public int Cantidadcargadores = 2;
    [SerializeField] private float velocidadGiro = 100f;

    void Update() {
        Rotar();

    }

    private void Rotar() {
        transform.Rotate(new Vector3(0, Time.deltaTime * velocidadGiro, 0));


    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            bool atope = other.gameObject.GetComponentInChildren<Arma>().IncrementarCargadores(Cantidadcargadores);
            if (atope == false) {
                Destroy(this.gameObject);

            }
            Arma arma = other.gameObject.GetComponentInChildren<Arma>();

        }

    }
}
