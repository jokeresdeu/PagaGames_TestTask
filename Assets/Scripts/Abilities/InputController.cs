using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Joystick joystick;
    Vector3 direction;
    public Vector3 Direction { get { return direction; } }
    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }
    void Update()
    {
        direction.z = joystick.Vertical;
        direction.x = joystick.Horizontal;
    }
}
