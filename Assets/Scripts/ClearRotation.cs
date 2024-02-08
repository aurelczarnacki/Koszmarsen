using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearRotation : MonoBehaviour
{
    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(-90f, 0f, 0f);
        transform.rotation = targetRotation;
    }
}
