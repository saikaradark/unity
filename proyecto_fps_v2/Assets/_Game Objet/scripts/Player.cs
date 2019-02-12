using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] Text txtVida;
    [SerializeField] int salud = 100;
    private const int SALUD_MAXIMA = 100;//constante en mayus separadas con guion bajo
    [SerializeField] Arma [] armas;
    private bool esInmune;
    private bool estaVivo;
    public int armaActiva = 0;

    private void Star() {
        txtVida.text = salud.ToString();
        
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ApretarGatillo();
            print("bam bam");

        }
        if (Input.GetKeyDown(KeyCode.R)) {
            armas[armaActiva].Reload();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarArma(1);
        }
    }
    public bool IncrementarSalud(int incremento){
        bool atope = false;
        if (salud < SALUD_MAXIMA) {
            salud = salud + incremento;//salud+=incremento
            salud = Mathf.Min(salud, SALUD_MAXIMA);//tope de la vida
            txtVida.text = salud.ToString();
        }
        return atope;
    }

    public void RecibirDanyo(int danyo) {
        salud = salud - danyo;
        salud = Mathf.Max(salud, 0);
        txtVida.text = salud.ToString();
    }

    private void Morir() {

    }

    private void ApretarGatillo() {
        armas[armaActiva].ApretarGatillo();
    }
    private void CambiarArma(int armaAActivar)
    {
        for(int i = 0; i < armas.Length; i++)
        {
            armas[i].gameObject.SetActive(false);//desactivamos armas no seleccionadas
        }
        armas[armaAActivar].gameObject.SetActive(true);
        armaActiva = armaAActivar;
    }

    

    

}
