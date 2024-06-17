using UnityEngine;

public class ChangeMatirials : MonoBehaviour
{
    public GameObject[] GroundsGmaeObjects;
    public Material[] Groundmaterials;
    private int currentMaterialIndex = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (Groundmaterials.Length > 0)
            {
                foreach (GameObject obj in GroundsGmaeObjects)
                {
                    Renderer rend = obj.GetComponent<Renderer>();
                    if (rend != null)
                    {
                        rend.material = Groundmaterials[currentMaterialIndex];
                    }
                }
            }
        }

    }



}
