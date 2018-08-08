using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImitateMainCamera : MonoBehaviour {

    private Camera cam;

    private void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    //MEJORAR!
    void Update () {
        cam.transform.rotation = Quaternion.Inverse(Camera.main.transform.rotation);
        cam.transform.Rotate(Vector3.up * 180, Space.Self);
    }
}
