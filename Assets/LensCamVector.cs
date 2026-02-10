using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.LightTransport;

public class LensCamVector : MonoBehaviour
{
    public Transform mainCameraPos;
    public Transform lensCamera;
    public Transform glassPos;
    public Transform glassRot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // The vector between the player and magnifying glass
        Vector3 direction = glassPos.position - mainCameraPos.position;

        // How lensCamera should be rotated
        lensCamera.rotation = Quaternion.LookRotation(direction, glassRot.up);

    }
}
