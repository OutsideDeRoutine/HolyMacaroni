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
        RenderTexture currentRT = new RenderTexture(OPCamera.pixelHeight*2, OPCamera.pixelHeight*2,24);
        Mat.SetTexture("_PortalTex", currentRT);
        OPCamera.targetTexture = currentRT;
    }

    void OnTriggerEnter(Collider collider)
    {
        Vector2 distXY = new Vector2(collider.transform.position.x - this.transform.position.x, collider.transform.position.y - this.transform.position.y);
        collider.transform.position = OPPortal.position;
        Quaternion rot = this.transform.rotation;

        float angle = Mathf.Abs(Quaternion.Angle(OPPortal.rotation, rot)) - 180;
        collider.transform.Rotate(Vector3.up * angle, Space.Self);
        collider.transform.Translate(distXY);
    }


}
