using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    private const int MUNICION_MAX = 30;
    private const int CARGADORES_MAX = 6;// Numero maximos de cargadores.
    private AudioSource audioSuorce;
    public enum Estado { Disponible, Descargada, Recargando, Disparando };
    public Estado estado = Estado.Disponible;
    [SerializeField] GameObject prefabProyectil;// Seria la bala.
    [SerializeField] Transform spawmPoint;//El punto desde donde se genera la bala.
    [SerializeField] float cadencia;//tiempo entre disparos.
    [SerializeField] int capacidadCargador;//cantidad de balas por cargador.
    [SerializeField] float force = 100;//fuerza de la bala
    [SerializeField] int numeroCargadores;//cargadores con los que empiezas
    [SerializeField] float tiempoRecarga;//tiempo que tarda en hacerse la animacion de recarga
    [SerializeField] int municionCargador;//cantidad de balas 
    [SerializeField] AudioClip acDisparo;
    [SerializeField] AudioClip acGatillazo;
    [SerializeField] AudioClip acRecarga;
    [SerializeField] AudioClip AcCambioArma;
    [SerializeField] Text txtCargadores;
    [SerializeField] Text txtMunicion;
    private void Start()
    {
        audioSuorce = GetComponent<AudioSource>();
        txtMunicion.text = municionCargador.ToString();
        txtCargadores.text = numeroCargadores.ToString();
    }

    public void ApretarGatillo()
    {
        if (estado == Estado.Disponible)
        {
            Disparar();
        }
        else if (estado == Estado.Descargada)
        {
            audioSuorce.PlayOneShot(acGatillazo);
        }
    }
    public void Reload()
    {
        if (estado != Estado.Recargando && numeroCargadores > 0 && municionCargador != capacidadCargador)
        {
            estado = Estado.Recargando;
            numeroCargadores--;
            municionCargador = capacidadCargador;
            audioSuorce.PlayOneShot(acRecarga);
            Invoke("ActivarArma", tiempoRecarga);
        }
    }
    private void Disparar()
    {
        GameObject proyectil = Instantiate(prefabProyectil, spawmPoint.position, spawmPoint.rotation);
        proyectil.GetComponent<Rigidbody>().AddForce(spawmPoint.forward * force);
        audioSuorce.PlayOneShot(acDisparo);
        municionCargador--;

        if (municionCargador == 0)
        {
            estado = Estado.Descargada;
        }
        else
        {
            estado = Estado.Disparando;
            Invoke("ActivarArma", cadencia);
        }
    }
    private void ActivarArma()
    {
        this.estado = Estado.Disponible;
    }
    public bool IncrementarCargadores(int incremento)
    {
        bool atope = false;
        if (numeroCargadores < CARGADORES_MAX)
        {
            numeroCargadores = numeroCargadores + incremento;//salud+=incremento
            numeroCargadores = Mathf.Min(numeroCargadores, CARGADORES_MAX);//tope de la vida
            txtCargadores.text = numeroCargadores.ToString();
        }
        return atope;

    }
    public bool IncrementarMunicion(int incremento)
    {
        bool atope = false;
        if (municionCargador < MUNICION_MAX)
        {
            municionCargador = municionCargador + incremento;
            municionCargador = Mathf.Min(municionCargador, MUNICION_MAX);
            txtMunicion.text = municionCargador.ToString();
        }
        return atope;


    }
}