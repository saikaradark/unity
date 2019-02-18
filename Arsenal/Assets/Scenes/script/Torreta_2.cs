using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta_2 : MonoBehaviour
{
    public Transform puntoMira;
    private void update()
    {
        RaycastHit hit;
        if (Input.GetButtonDown("Fire"))
        {
            Ray rayo = new Ray(puntoMira.position, puntoMira.forward);
            Debug.DrawRay(puntoMira.position, puntoMira.forward, Color.red, 5);
            bool hayImpacto = Physics.Raycast(rayo, out hit, Mathf.Infinity);
            if (hayImpacto)
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(Vector3.forward * 100);
                }
            }
        }
    }
}
