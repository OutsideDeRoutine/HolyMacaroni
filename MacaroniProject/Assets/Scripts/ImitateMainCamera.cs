using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImitateMainCamera : MonoBehaviour {

    private Camera cam;
    public Camera OPcam;

    private void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    //MEJORAR!
    void Update () {
        //ROTATION
        cam.transform.rotation = Quaternion.Inverse(Camera.main.transform.rotation);
        cam.transform.Rotate(Vector3.up * 180);

        //LOCATION



        //DISTANCE
        float dist = Vector3.Distance(Camera.main.transform.position, this.GetComponentInParent<Transform>().position);
        OPcam.fieldOfView = (1/dist)*50 + 60;
    }
}
