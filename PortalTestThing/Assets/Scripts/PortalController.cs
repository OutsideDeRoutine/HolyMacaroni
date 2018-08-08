using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalController : MonoBehaviour {

    [SerializeField] Camera OPCamera;
    [SerializeField] Material Mat;

    [SerializeField] Transform OPPortal;

    //Set PortalTextures
    void Awake()
    {
        RenderTexture currentRT = new RenderTexture(OPCamera.pixelHeight, OPCamera.pixelHeight,24);
        Mat.SetTexture("_PortalTex", currentRT);
        OPCamera.targetTexture = currentRT;
    }

    void OnTriggerEnter(Collider collider)
    {
        collider.transform.position = OPPortal.position;
        collider.transform.Rotate(Vector3.up * 180, Space.Self);
    }


}
