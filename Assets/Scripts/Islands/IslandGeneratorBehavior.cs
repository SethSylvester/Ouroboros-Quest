using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGeneratorBehavior : MonoBehaviour
{
    public List<Transform> spawnLocations;

    [SerializeField]
    private GameObject largeTree;
    [SerializeField]
    private GameObject smallTree;
    [SerializeField]
    private GameObject bush;

    private IslandTypes biome;
    private Color32 groundColor;

    private Color32 DarkGreen = new Color32(18, 178, 25, 1);
    //[SerializeField]
    //private GameObject islandFloor;

    // Start is called before the first frame update
    private void Start()
    {
        biome = (IslandTypes)Random.Range(1, 3);
        GenerateGrassLands();
    }

    private void GenerateGrassLands()
    {
        groundColor = DarkGreen;

        //islandFloor.GetComponent<Renderer>().material.color = groundColor;

        float rng;
        float rngScale;

        for (int i = 0; i < spawnLocations.Count; i++)
        {
            rng = Random.Range(1, 4);
            GameObject enviromentObject;

            //One in three chance to spawn a bush.
            if (rng == 1)
            {
                enviromentObject = Instantiate(bush);
                enviromentObject.transform.position = spawnLocations[i].transform.position;
                //Makes it a little bigger depending on the number generated
                rngScale = (Random.Range(5, 7)/2.5f);
                enviromentObject.transform.localScale = new Vector3(rngScale, rngScale, rngScale);
            }
        }
    }
}

public enum IslandTypes
{
    forest,
    grasslands
}