using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneScript : MonoBehaviour
{

    private float delay = 2f;
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
            Destroy(other.gameObject);
        }
    }


    public void Restart()
    {
        ScreenShake.screenShake.ShakeScreen(0.3f, 0.25f);
        StartCoroutine(Death(delay));
        print("ahmedMohsen");
    }

    IEnumerator Death(float delay)
    {
        LevelLoaderScriipt.levelLoaderScriipt.RunAnimation(0.5f);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
