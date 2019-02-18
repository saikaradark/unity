using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta_1 : MonoBehaviour
{
    public GameObject prefabProyectil;
    public Transform puntoGeneracion;
    public float fuerza;
    public float multiplicadoFuerza;
    private float x;
    private float y;
    

     void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(y, x, 0);
        if (Input.GetKey(KeyCode.Space))
        {
            fuerza += Time.deltaTime;

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Disparar();
            fuerza = 0f;
        }
    }
    void Disparar()
    {
        GameObject proyectil = Instantiate(prefabProyectil, puntoGeneracion.position, puntoGeneracion.rotation);
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fuerza * multiplicadoFuerza);
        


    }
}