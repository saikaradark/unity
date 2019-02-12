using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class    Chorrodesangre : MonoBehaviour {


    private const int TIME_TO_DESTROY = 3;


    void Start() {
        Destroy(this.gameObject, TIME_TO_DESTROY);
    }

}
