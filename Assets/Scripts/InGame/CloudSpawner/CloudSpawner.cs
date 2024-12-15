using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [Header("Border")]
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform rightBorder;

    [Header("Random Range")]
    [Range(0, 20)]
    [SerializeField] private int count;

    [Header("Cloud")]
    [SerializeField] private GameObject[] objectsCloud;

    private void Start()
    {
        for(int i = 0; i < count; i++)
        {
            Vector2 position = new Vector2(
                Random.Range(leftBorder.position.x, rightBorder.position.x),
                Random.Range(leftBorder.position.y, rightBorder.position.y));

            Instantiate(RandomCloud(), position, Quaternion.identity);
        }
    }

    private GameObject RandomCloud()
    {
        return objectsCloud[Random.Range(0, objectsCloud.Length)];
    }
}
