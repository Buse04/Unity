using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour
{
    [SerializeField] int SceneIndex;
    Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneIndex);    
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(SceneIndex);
    }

}
