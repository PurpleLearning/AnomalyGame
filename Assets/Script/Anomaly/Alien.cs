using UnityEngine;

public class Alien : MonoBehaviour, IAnomaly
{
    //[SerializeField] private bool isAnomaly = false;
    [SerializeField] private string headObjectName = "head";
    
    void Start()
    {
        
    }
    
    // Implementation of IAnomaly interface
    public void SetAsAnomaly()
    {
        //isAnomaly = true;
        ChangeAlienHeadColor();
        gameObject.tag = "anomaly";
    }
    
    // Implementation of IAnomaly interface
    public void RevertAnomaly()
    {
        //isAnomaly = false;
        gameObject.tag = "normal";  
        ResetHeadColor();
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
        
        // Find the material
        Material[] materials = renderer.materials;
        
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i] != null && materials[i].name.Contains("crystal"))
            {
                // Change to red
                materials[i].color = Color.red;
                return;
            }
        }
    }
    
    void ResetHeadColor()
    {
         
        Renderer renderer = transform.Find(headObjectName)?.GetComponent<Renderer>();
        
        if (renderer == null) return;
        
        Material[] materials = renderer.materials;
        
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i] != null && materials[i].name.Contains("crystal"))
            {
                // Reset to white or original color
                materials[i].color = Color.cyan;
                return;
            }
        }
    }
}