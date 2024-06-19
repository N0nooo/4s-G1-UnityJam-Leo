using System;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private GameObject winscreen;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winscreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
