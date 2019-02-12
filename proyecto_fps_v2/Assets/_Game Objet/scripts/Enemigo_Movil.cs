using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Movil : Enemigo
{
    public float velocidad;
    private float angulo;
    private const int TIEMPO_INICIO = 1;
    private const int TIEMPO_ENTRE_ROTACIONES = 3;
    private const float ANGULO_MINIMO = -90F;
    private const float ANGULO_MAXIMO = 90F;

    public override void Start(){
        InvokeRepeating("Rotar", TIEMPO_INICIO, TIEMPO_ENTRE_ROTACIONES);//hardcode
        base.Start();
        
    }
     public void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad);

    }
    private void Rotar() {
        angulo = Random.Range(-45f, 45f);    
        transform.Rotate(new Vector3(0, angulo, 0));

    }
}
