using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImitateMainCamera : MonoBehaviour {

    private Camera cam;

    private void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    void Update () {
        //Invertir giro (?) LA CAMARA HA DE SEGUIR EL PUNTO DE VISTA DEL JUGADOR!
        cam.transform.rotation = Camera.main.transform.rotation * new Quaternion(-1,0,0,0);

    }
}
