using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 rotation = new Vector3(0.0f, 0.75f, 0.0f);
        transform.Rotate(rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}
