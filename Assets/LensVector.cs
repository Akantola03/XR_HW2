using UnityEngine;

public class LensVector : MonoBehaviour
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
        //Vector3 direction = glass.position - mainCamera.position;
        //lensCamera.rotation = Quaternion.LookRotation(direction);

        /*
        // Put the lens camera at the glass position
        lensCamera.position = glass.position; 
        // Make the lens camera look in the same direction as the main camera
        lensCamera.rotation = Quaternion.LookRotation(mainCamera.forward, mainCamera.up);
        */    
       }
}
