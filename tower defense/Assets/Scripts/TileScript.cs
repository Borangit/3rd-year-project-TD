using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public GameObject turretPrefab; // Drag your Turret prefab here in the Inspector

    private bool hasTurret = false; // To ensure only one turret can be spawned on the tile

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.D)){
            SpawnTurret();
            hasTurret = true; // Mark that the tile now has a turret
         }

    }

    void OnMouseDown()
    {
        if (!hasTurret)
        {
            SpawnTurret();
            hasTurret = true; // Mark that the tile now has a turret
        }
    }

    void SpawnTurret()
    {
        // Adjust the position to be 0.2 units above the tile's position
        Vector3 spawnPosition = transform.position + new Vector3(0, 0.2f, 0);
        
        // Spawn the turret at the adjusted position
        Instantiate(turretPrefab, spawnPosition, Quaternion.identity);
    }

}
