using UnityEngine;
using UnityEngine.InputSystem;


public class LightSwitch : MonoBehaviour
{
    public Light lightsource;
    public bool IsGreen = false;
    public InputActionReference action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightsource = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (IsGreen)
            {
                lightsource.color = Color.white;
            }
            else
            {
                lightsource.color = Color.green;
            }
            IsGreen = !IsGreen;
        };
    }
}
