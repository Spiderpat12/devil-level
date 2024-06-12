using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour
{

    private float delay = 0.15f;
    [HideInInspector] public RestartSceneScript restartSceneScript;

    private void Awake()
    {
        restartSceneScript = this;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Restart();
        }
    }


    public void Restart()
    {
        ScreenShake.screenShake.ShakeScreen(0.38f, 0.5f);
        StartCoroutine(Death(delay));
        print("ahmedMohsen");
    }

    IEnumerator Death(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
