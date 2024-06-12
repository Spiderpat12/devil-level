using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAnimationScript : MonoBehaviour
{
    public float rotationSpeed;


    public void Update()
    {
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }


}
