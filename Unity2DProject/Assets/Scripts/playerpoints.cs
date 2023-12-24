using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerpoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    

    void Awake()
    {
       
        text.text = Score.totalScore.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("food"))
        {
            
            Destroy(other.gameObject);
            Score.totalScore++;
            text.text = Score.totalScore.ToString();
        }
    }
}
