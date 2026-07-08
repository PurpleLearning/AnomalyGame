using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] private bool isAnomaly = false;
    [SerializeField] private string headObjectName = "Head";
    
    void Start()
    {
        isAnomaly = true;
        
        if (isAnomaly)
        {
            ChangeAlienHeadColor();
            AnomalyTagAdded();
        }
    }
    
    void ChangeAlienHeadColor()
    {
        // From Alien -> Look for the child 'head' to change the color 
        Renderer renderer = transform.Find(headObjectName)?.GetComponent<Renderer>();
        
        if (renderer == null)
        {
            Debug.LogError("Head object or its Renderer not found!");
            return;
        }
        
        // Fiidn the material
        Material[] materials = renderer.materials;
        
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i] != null && materials[i].name.Contains("crystal"))
            {
                // change to red
                materials[i].color = Color.red;
                return;
            }
        }
    }


    void AnomalyTagAdded()
    {
        gameObject.tag = "anomaly";
    }
    
}