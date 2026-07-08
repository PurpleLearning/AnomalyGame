using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    public List<GameObject> listOfAnomalies = new List<GameObject>();
    private GameObject currentAnomaly = null;
    
    void Start()
    {
        // Wait a frame to ensure everything is initialized
        Invoke("SelectRandomAnomaly", 0.1f);
    }
    
    void SelectRandomAnomaly()
    {
        // Check if there are any anomalies in the list
        if (listOfAnomalies.Count == 0)
        {
            Debug.LogWarning("No anomalies in the list!");
            return;
        }
        
        // Pick a random index
        int randomIndex = Random.Range(0, listOfAnomalies.Count);
        GameObject selectedAnomaly = listOfAnomalies[randomIndex];
        
        if (selectedAnomaly != null)
        {
            currentAnomaly = selectedAnomaly;
            
            // Works with ANY object that implements IAnomaly!
            IAnomaly anomalyComponent = selectedAnomaly.GetComponent<IAnomaly>();
            
            if (anomalyComponent != null)
            {
                anomalyComponent.SetAsAnomaly();
            }
        }
    }
    
}