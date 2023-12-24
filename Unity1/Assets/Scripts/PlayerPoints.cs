using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        text.text = score.totalScore.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Elmas"))
        {
            audio.Play();
            Destroy(other.gameObject);
            score.totalScore++;
            text.text = score.totalScore.ToString();
        }
    }
}
