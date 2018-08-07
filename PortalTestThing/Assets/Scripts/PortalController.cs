using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalController : MonoBehaviour {

    [SerializeField] Camera OPCamera;
    [SerializeField] Material Mat;

    //Set PortalTextures
    void Awake()
    {
        RenderTexture currentRT = new RenderTexture(OPCamera.pixelHeight, OPCamera.pixelHeight,24);
        Mat.SetTexture("_PortalTex", currentRT);
        OPCamera.targetTexture = currentRT;
    }
}
