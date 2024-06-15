using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [Header("------Position------")]
    public GameObject Position;
    public float delay;


    private GameObject Player;
    MovementPlayerScript movementPlayerScript;



    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            movementPlayerScript = other.GetComponent<MovementPlayerScript>();
            movementPlayerScript.RunParticles(movementPlayerScript.PlayerParticles[0], other.transform.position);
            other.gameObject.SetActive(false);
            Player = other.gameObject;
            StartCoroutine(Teleport(delay));
        }
    }


    IEnumerator Teleport(float delay)
    {
        yield return new WaitForSeconds(delay);
        movementPlayerScript.RunParticles(movementPlayerScript.PlayerParticles[0], Position.transform.position);
        Player.gameObject.SetActive(true);
        Player.gameObject.transform.position = new Vector3(Player.gameObject.transform.position.x, Position.transform.position.y, Position.transform.position.z);
    }

}
