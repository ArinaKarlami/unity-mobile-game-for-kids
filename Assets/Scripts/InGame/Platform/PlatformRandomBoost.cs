using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRandomBoost : MonoBehaviour
{
    [Header("Random Range")]
    [Range(-1, 100)]
    [SerializeField] private int randomValue = 50;

    [Header("Count Boosts")]
    [SerializeField] private int countBoosts;

    [Header("Boost")]
    [SerializeField] private GameObject[] boosts;

    private PlatformRandomGrass randomGrass;

    private float top = 1.5f;

    private void Start()
    {
        randomGrass = GetComponent<PlatformRandomGrass>();

        bool spawn = Random.Range(0, 100) < randomValue;

        if (spawn)
        {
            for (int i = 0; i < Random.Range(0, countBoosts); i++)
            {
                Vector2 pos = randomGrass.RandomPosition();
                pos = new Vector2(pos.x, pos.y + top);
                Instantiate(RandomBoost(), pos, Quaternion.identity);
            }
        }
    }

    private GameObject RandomBoost()
    {
        return boosts[0];
    }
}
