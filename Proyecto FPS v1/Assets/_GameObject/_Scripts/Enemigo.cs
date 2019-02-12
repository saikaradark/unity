using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int danyo;// Daño que provoca durante el ataque
    public int salud;//salud enemigo
    public float distanciaDeteccion;//a partir de que distancia te ataca el enemigo
    public GameObject prefabExplosion;//prefab explosion muerte
    private  TextMesh tm;//Borrar en el futuro
    protected Transform transformPlayer;
    public  virtual void Start() {
        transformPlayer = GameObject.Find("Player").transform;
        tm = GetComponentInChildren<TextMesh>();//borrar en el futuro
        tm.text = salud.ToString();  // borrar en el futuro     
    }
    private void OnCollisionEnter(Collision collision) {
        /*
         * 1. Saber si ha colisionado 
         * 2. hacer  daño al colisionar con player
         * 3. generar sonido explosion 
         * 4. generar un sistema de particulas de explosion
         * 5. destruir el gameObject
          */
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().RecibirDanyo(danyo);
            Morir();
        }
    }
    public void Morir() {
        Instantiate(prefabExplosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    public void RecibirDanyo(int danyoRecibido) {
        salud = salud - danyoRecibido;
        //tm.text = salud .ToString();//borrar en el futuro
        if (salud <= 0) {//esta muerto
            
            Morir();   
        } else {
            //sonido de dolor 
        }
    }   
}
