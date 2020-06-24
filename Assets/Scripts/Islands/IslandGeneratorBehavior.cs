using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGeneratorBehavior : MonoBehaviour
{
    private islandTypes biome;
    private Color32 groundColor;

    private Color32 DarkGreen = new Color32(18, 178, 25, 1);

    [SerializeField]
    GameObject islandFloor;

    // Start is called before the first frame update
    void Start()
    {
        biome = (islandTypes)Random.Range(1, 3);
        GenerateGrassLands();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GenerateGrassLands()
    {
        groundColor = DarkGreen;

        islandFloor.GetComponent<Renderer>().material.color = DarkGreen;
    }
}

public enum islandTypes
{
    forest,
    grasslands
}