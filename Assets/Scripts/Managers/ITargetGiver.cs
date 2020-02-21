using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetGiver 
{
    List<Rigidbody> Enemies { get; }
    Rigidbody Player { get; }
}
