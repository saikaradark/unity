using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Listo : Enemigo_Movil {

    
    private void Update() {
        if (EstaADistaciaDeAtaque()) {
            //a por el
            transform.LookAt(transformPlayer);
          
        }
        base.Update();
    }



    private bool EstaADistaciaDeAtaque() { 
        bool estaADistancia = false;
        if (Vector3.Distance(transform.position,transformPlayer.position) < distanciaDeteccion) {
            estaADistancia = true;
            //Lo tengo a tiro
        }

        return estaADistancia;
    }
}
