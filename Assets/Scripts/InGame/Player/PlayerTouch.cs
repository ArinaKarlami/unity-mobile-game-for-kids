using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTouch : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            playerHealth.Add(1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("NextLevel"))
        {
            Invoke("NextLevel", .5f);
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            playerHealth.Damage(1);
            Destroy(collision.gameObject);
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
