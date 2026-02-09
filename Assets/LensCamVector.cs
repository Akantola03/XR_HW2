using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;

public class LensCamVector : MonoBehaviour
{
    public Transform mainCamera;
    public Transform lensCamera;
    public Transform glass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Position the lens camera at the glass 
        //lensCamera.position = glass.position - mainCamera.forward;
        // Cancel out parent rotation so the lensCamera doesn't inherit the lens rotation
        //lensCamera.localRotation = Quaternion.identity; 
        // Apply main camera orientation 
        //lensCamera.rotation = Quaternion.LookRotation(mainCamera.forward, mainCamera.up);
        
        Vector3 direction = glass.position - mainCamera.position;
        lensCamera.localRotation = Quaternion.identity;
        lensCamera.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}
