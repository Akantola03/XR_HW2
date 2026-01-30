using UnityEngine;
using UnityEngine.Device;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerLocation : MonoBehaviour
{
    public bool IsOutside = false;
    public InputActionReference action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position= new Vector3(0.0f, 3.0f, -5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            if (IsOutside)
            {
                transform.position = new Vector3(15.0f, 5.0f, -15.0f);
                transform.Rotate(0, -45, 0);
            }
            else
            {
                transform.position = new Vector3(0.0f, 3.0f, -5.0f);
                transform.Rotate(0, 45, 0);
            }
            IsOutside = !IsOutside;
        };
    }
}
