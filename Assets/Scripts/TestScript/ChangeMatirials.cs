using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMatirials : MonoBehaviour
{
    public LevelNumber levelNumber;
    public List<GameObject> GroundsGmaeObjects = new List<GameObject>();
    public Material[] Groundmaterials;
    public string[] tagsToSearch;

    private void Start()
    {
        levelNumber.value = SceneManager.sceneCount;
    }

    void Update()
    {

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
                    switch (levelNumber.value)
                    {
                        case int n when n >= 1 && n <= 16:
                            rend.material = Groundmaterials[0];
                            break;
                        case int n when n >= 16 && n <= 20:
                            rend.material = Groundmaterials[1];
                            break;
                        case int n when n >= 20 && n <= 24:
                            rend.material = Groundmaterials[2];
                            break;
                        case int n when n >= 24 && n <= 28:
                            rend.material = Groundmaterials[3];
                            break;
                        case int n when n >= 28 && n <= 32:
                            rend.material = Groundmaterials[4];
                            break;
                        case int n when n >= 32 && n <= 36:
                            rend.material = Groundmaterials[5];
                            break;
                    }
                }
            }
        }


    }



}
