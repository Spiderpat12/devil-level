using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMatirials : MonoBehaviour
{
    public int LevelNumber;
    public List<GameObject> GroundsGmaeObjects = new List<GameObject>();
    public Material[] Groundmaterials;
    public string[] tagsToSearch;

    public GameObject camera1;
    private Camera cameraProprties;

    private void Start()
    {
        camera1 = GameObject.FindGameObjectWithTag("MainCamera");
        cameraProprties = camera1.GetComponent<Camera>();
    }

    void Update()
    {

        LevelNumber = SceneManager.GetActiveScene().buildIndex;

        GroundsGmaeObjects.Clear();

        foreach (string tag in tagsToSearch)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

            GroundsGmaeObjects.AddRange(objectsWithTag);
        }

        if (Groundmaterials.Length > 0)
        {
            foreach (GameObject obj in GroundsGmaeObjects)
            {
                Renderer rend = obj.GetComponent<Renderer>();
                if (rend != null)
                {
                    switch (LevelNumber)
                    {
                        case int n when n >= 0 && n <= 16:
                            cameraProprties.backgroundColor = new Color(0.8679245f, 0.7232705f, 0, 0);
                            rend.material = Groundmaterials[0];
                            break;
                        case int n when n >= 16 && n <= 20:
                            cameraProprties.backgroundColor = new Color(0.8679245f, 0.65f, 0, 0);
                            rend.material = Groundmaterials[1];
                            break;
                        case int n when n >= 20 && n <= 24:
                            cameraProprties.backgroundColor = new Color(0.8679245f, 0.6f, 0, 0);
                            rend.material = Groundmaterials[2];
                            break;
                        case int n when n >= 24 && n <= 28:
                            cameraProprties.backgroundColor = new Color(0.8679245f, 0.6f, 0, 0);
                            rend.material = Groundmaterials[3];
                            break;
                        case int n when n >= 28 && n <= 32:
                            cameraProprties.backgroundColor = new Color(0.8679245f, 0.575f, 0, 0);
                            rend.material = Groundmaterials[4];
                            break;
                        case int n when n >= 32 && n <= 36:
                            cameraProprties.backgroundColor = new Color(0.8679245f, 0.55f, 0, 0);
                            rend.material = Groundmaterials[5];
                            break;
                    }
                }
            }
        }


    }



}
