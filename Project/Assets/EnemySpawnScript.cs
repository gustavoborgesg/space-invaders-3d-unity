using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject enemy4Prefab;
    public GameObject enemy5Prefab;

    public uint enemiesPerRow;
    
    public Camera mainCamera;
    
    public float marginsX;
    public float startY;
    public float rowSpacing;
    
    void Start()
    {
        SpawnAll();
    }

    void Update()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length == 0)
        {
            SpawnAll();
        }
    }

    void SpawnAll()
    {
        Vector3 blBound = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 trBound = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        float rowY   = startY; // bottom line of the row
        float leftX  = blBound.x + marginsX;
        float rightX = trBound.x - marginsX;

        rowY = SpawnRow(rowY, leftX, rightX, enemy1Prefab) + rowSpacing;
        rowY = SpawnRow(rowY, leftX, rightX, enemy2Prefab) + rowSpacing;
        rowY = SpawnRow(rowY, leftX, rightX, enemy3Prefab) + rowSpacing;
        rowY = SpawnRow(rowY, leftX, rightX, enemy4Prefab) + rowSpacing;
        rowY = SpawnRow(rowY, leftX, rightX, enemy5Prefab) + rowSpacing;
    }

    float SpawnRow(float rowY, float leftX, float rightX, GameObject enemyPrefab)
    {
        float   width     = rightX - leftX;
        Vector3 enemySize = enemyPrefab.GetComponent<MeshCollider>().bounds.size;
        float   spacing   = (width - enemySize.x * enemiesPerRow) / (enemiesPerRow - 1);
        float   curX      = leftX + enemySize.x / 2;

        for (uint i = 0; i < enemiesPerRow; ++i)
        {
            Instantiate(enemyPrefab, new Vector3(curX, rowY + enemySize.y / 2, enemyPrefab.transform.position.z), enemyPrefab.transform.rotation);
            curX += spacing;
        }

        return rowY + enemySize.y;
    }
}
