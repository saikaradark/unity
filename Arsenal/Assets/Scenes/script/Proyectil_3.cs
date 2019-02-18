using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil_3 : MonoBehaviour{
    public float fuerzaExplosion;
    public float radio;
    public float tiempoParaExplotar;
    public float fuerzaSalto;
    public LayerMask capaEnemigos;
    void Start(){
        Invoke("Detonar", tiempoParaExplotar);
    }
    void Update(){
        
    }
    private void Detonar(){
       GetComponent<Rigidbody>().isKinematic = true;
       Collider[] afectados = Physics.OverlapSphere(transform.position, radio,capaEnemigos);
       foreach(Collider afectado in afectados)
        {
         if(afectado.GetComponent<Rigidbody>() != null){

           afectado.GetComponent<Rigidbody>().AddExplosionForce(
               fuerzaExplosion,
               transform.position,
               radio,
               fuerzaSalto);
         }
        }
    }
}
