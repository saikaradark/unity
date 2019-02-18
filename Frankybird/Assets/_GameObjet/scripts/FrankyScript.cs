using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrankyScript : MonoBehaviour {
    [SerializeField] GameObject sangrePrefab;
    [SerializeField] private float force = 10f;
    [SerializeField] AudioClip aleteo;
    [SerializeField] AudioClip golpe;
    [SerializeField] AudioClip Puntuacion;
    [SerializeField] float velocidadRotacion = -5f;
    //public float force = 10f;// Alternativa no encapsulada
    private Rigidbody rb;
    private AudioSource audioSource;
    private GameObject gestordeljuego;
	void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        gestordeljuego = GameObject.Find("gestordeljuego");
    }
	void Update () {
        transform.rotation = Quaternion.Euler(new Vector3((rb.velocity.y * velocidadRotacion), 0, 0));
        if (Input.GetKeyDown(KeyCode.Space)) {
            impulsar();
        }	
	}
    void impulsar() {
      
        rb.AddForce(Vector3.up * force , ForceMode.Impulse);
        audioSource.PlayOneShot(aleteo);
    }
    private void OnCollisionEnter(Collision collision) {
        //hacer una llamada a finalizar juego del gestor 
        if (collision.gameObject.CompareTag("Limite") == false) {
            gestordeljuego.GetComponent<gestordeljuego>().FinalizarPartida();
            GameObject sangre = Instantiate(sangrePrefab);
            sangre.transform.position = this.transform.position;
            audioSource.PlayOneShot(golpe);
            Destroy(this.gameObject);
        }
    }
    private void OntriggerExit(Collider other) {
        int puntos = gestordeljuego.GetComponent<gestordeljuego>().Puntos;
        puntos++;// puntos = puntos + 1;
        gestordeljuego.GetComponent<gestordeljuego>().Puntos = puntos;
    }
}
