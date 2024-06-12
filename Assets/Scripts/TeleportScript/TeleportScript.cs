using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [Header("------Positions------")]
    public GameObject[] Position;




    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, Position[0].transform.position.y, Position[0].transform.position.z);
        }
    }

}
