using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts_Player : MonoBehaviour{
    [SerializeField] GameObject linterna;
    [SerializeField] AudioSource audioSource;

    void Update()
    { if (Input.GetKeyDown(KeyCode.L)) {
            linterna.SetActive(!linterna.activeSelf);//nueva forma de  hacerlo//
        } 
        else if (Input.GetButtonDown("Fire1")) {
            audioSource.Play();

        }
        
    }
}
