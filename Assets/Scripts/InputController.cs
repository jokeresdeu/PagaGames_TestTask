using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    Vector3 direction;
    public Vector3 Direction { get { return direction; } }
    void Update()
    {
        direction.z = joystick.Vertical;
        direction.x = joystick.Horizontal;
    }
}
