using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformRandomSpike : MonoBehaviour
{
    [Header("Random Range")]
    [Range(-1, 100)]
    [SerializeField] private int randomValue = 20;

    [Header("Count Spikes")]
    [SerializeField] private int countSpikes;

    [Header("Spike")]
    [SerializeField] private GameObject spike;

    private PlatformRandomGrass randomGrass;

    private int timeSpawn = 20;
    private float timeCount = 0.5f;

    private void Start()
    {
        randomGrass = GetComponent<PlatformRandomGrass>();

        int number = SceneManager.GetActiveScene().buildIndex;
        bool spawn = Random.Range(0, 100) < (randomValue + number * timeSpawn);

        if(spawn)
        {
            int minCount = (int) (number * timeCount);
            minCount = minCount <= countSpikes ? minCount : countSpikes;
            for (int i = 0; i < Random.Range(minCount, countSpikes); i++)
            {
                Instantiate(spike, randomGrass.RandomPosition(), Quaternion.identity);
            }
        }
    }
}
