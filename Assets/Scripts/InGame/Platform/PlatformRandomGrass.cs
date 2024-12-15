using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRandomGrass : MonoBehaviour
{
    [Header("Borders")]
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;

    [Header("Grass")]

    [SerializeField] private GameObject[] objectsGrass;

    [SerializeField] private int countGrass;

    [Header("Random Range")]
    [Range(-1, 100)]
    [SerializeField] private int randomValue = 80;

    private void Awake()
    {
        bool spawn = Random.Range(0, 100) < randomValue;

        if(spawn)
        {
            for(int i = 0; i < countGrass; i++)
            {
                
                Instantiate(RandomGrass(), RandomPosition(), Quaternion.identity);
            }
        }
    }

    private GameObject RandomGrass()
    {
        return objectsGrass[Random.Range(0, objectsGrass.Length)];
    }

    public Vector2 RandomPosition()
    {
        float x_ = Random.Range(leftBorder.position.x, rightBorder.position.x);
        float y_ = Random.Range(leftBorder.position.y, rightBorder.position.y);
        Vector2 position = new Vector2(x_, y_);
        return position;
    }
}
