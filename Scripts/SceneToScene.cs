using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will be used to send infromations from scene to scene
public class SceneToScene : MonoBehaviour
{
    void Start()
    {
        // Check if another instance of the script exists
        if (GameObject.FindObjectsOfType(GetType()).Length > 1)
        {
            // If another instance exists, destroy this GameObject
            Destroy(gameObject);
        }
        else
        {
            // If this is the first instance, don't destroy the GameObject when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
