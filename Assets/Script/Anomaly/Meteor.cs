using UnityEngine;

public class Meteor : MonoBehaviour, IAnomaly
{
    public GameObject anomalyMeteors;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anomalyMeteors.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetAsAnomaly()
    {
        anomalyMeteors.SetActive(true);
        gameObject.tag = "anomaly";
    }

    public void RevertAnomaly()
    {
        
        
    } 
    
}
