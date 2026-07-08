using UnityEngine;

public class Teleporter : MonoBehaviour, IAnomaly
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void SetAsAnomaly()
    {
        ChangeSize();
        gameObject.tag = "anomaly";
        
    }

    void ChangeSize()
    {
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    } 
    
    
    
    public void RevertAnomaly()
    {
        
        
    }
}
