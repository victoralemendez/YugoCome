using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { set; get; }

    public List<GameObject> tiles = new List<GameObject>();
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float titleLength = 5.9f;
    private int amnTiles = 20;
    private float safeZone = 15.0f;
    private int lastTileIndex;

    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();
        for (int i = 0; i < amnTiles; i++){
            if(i<2){
                SpawnTile(0);
            }else{
                SpawnTile();
            }

        }
       
	}
	
	// Update is called once per frame
	void Update () {
        if(playerTransform.position.z - safeZone > (spawnZ - amnTiles * titleLength)){
            SpawnTile();
            DeleteTile();
        }
  

    }

    void SpawnTile(int prefabIndex = -1){
        GameObject go;
        if(prefabIndex == -1){
            go = Instantiate(tiles[RandomTileIndex()]) as GameObject;
        }else{
            go = Instantiate(tiles[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += titleLength;
        activeTiles.Add(go);

    }

   void DeleteTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomTileIndex(){
        if(tiles.Count <= 1){
            return 0;
        }
        int randomIndex = lastTileIndex;
        while(randomIndex == lastTileIndex){
            randomIndex = Random.Range(0, tiles.Count);
        }
        lastTileIndex = randomIndex;
        return randomIndex;

    }
}
