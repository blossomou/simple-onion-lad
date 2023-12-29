using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] sushiPrefabs;

    [SerializeField] private BoxCollider2D spawnArea;
    [SerializeField] private GameObject reloadPrefab;
    [SerializeField] private float coolDown;

    [Range(0f, 1f)]
    [SerializeField] public float reloadChance = 0.05f;
    private float timer;
    private int sushiCreated;
    private int sushiMilestone;

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            timer = coolDown;
            sushiCreated++;

            if(sushiCreated > sushiMilestone && coolDown > .5f)
            {
                sushiMilestone += 10;
                coolDown -= .3f;
            }

            GameObject prefab = sushiPrefabs[Random.Range(0, sushiPrefabs.Length)];

            if(Random.value < reloadChance)
            {
                prefab = reloadPrefab;
            }

            float randomX = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            var position = new Vector2(randomX, transform.position.y);

            Instantiate(prefab, position, Quaternion.identity);

        }
        
    }

}
