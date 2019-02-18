using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta_3 : MonoBehaviour
{
    public GameObject prefabProyectil;
    public Transform puntoGeneracion;
    public float fuerza;
    private float x;
    private float y;

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(y, x, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }
    void Disparar()
    {
        GameObject proyectil = Instantiate(prefabProyectil, puntoGeneracion.position, puntoGeneracion.rotation);
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerza);



    }
}
