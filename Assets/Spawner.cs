using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spikePrefab;
    public GameObject platformPrefab;
    public GameObject stairPrefab;
    public GameObject blockPrefab;
    public GameObject lavaPrefab;
    public GameObject coinPrefab;
    public GameObject cratePrefab;
    public GameObject tntPrefab;
    public float spikeGap;
    public float spikeGapLimit;
    public float stairGap;
    public float stairGapLimit;
    public float blockGap;
    public float blockGapLimit;
    public float crateGap;
    public float crateGapLimit;
    public float caveGap;
    public float caveGapLimit;
    public float platformGap;
    public float platformGapLimit;
    public float lavaGap;
    public float lavaGapLimit;
    public bool twoStairCoins;


    // Start is called before the first frame update
    void Start()
    {
        spikeGap = 0f;
        platformGap = 0f;
        stairGap = 0f;
        blockGap = 0f;
        crateGap = 0f;
        platformGapLimit = 0.025f;
        spikeGapLimit = 0.50f;
        crateGapLimit = 0.5f;
        blockGapLimit = 0.25f;
        stairGapLimit = 0.75f;
        twoStairCoins = false;
        InvokeRepeating("spawnLava", 0f, 10f * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        spikeGap += Time.deltaTime;
        stairGap += Time.deltaTime;
        blockGap += Time.deltaTime;
        crateGap += Time.deltaTime;
        platformGap += Time.deltaTime;

        if (spikeGap >= spikeGapLimit && (blockGap < blockGapLimit))
        {
            spawnSpikes();
            spikeGap = 0f;
        }

        if (crateGap >= crateGapLimit)
        {
            spawnCrates();
            crateGap = 0f;
        }

        if (platformGap >= platformGapLimit)
        {
            spawnPlatform();
            platformGap = 0f;
        }

        else if (stairGap >= stairGapLimit)
        {
            int numCoins = Random.Range(5,15); 
            spawnStairs();
            spawnCoins(numCoins);
            stairGap = 0f;
        }

        else if (blockGap >= blockGapLimit)
        {
            spawnBlocks();
            blockGap = 0f;
        }
    }

    void spawnSpikes()
    {
        float scale = Random.Range(0.0250f, 0.050f);
        spikePrefab.transform.localScale = new Vector3(scale, scale, 0);
        int twoSpike = Random.Range(0,10);

        if (twoSpike >= 8)
        {
            Instantiate(spikePrefab, new Vector3(12f, 5f, 0), spikePrefab.transform.rotation);
            Instantiate(spikePrefab, new Vector3(12.5f, 5f, 0), spikePrefab.transform.rotation);
        }
        else
        {
            Instantiate(spikePrefab, new Vector3(12f, 5f, 0), spikePrefab.transform.rotation);
        }
        spikeGapLimit = Random.Range(0.25f, 2.0f);
    }

    void spawnStairs()
    {
        int twoStair = Random.Range(1, 10);
        float scale = Random.Range(0.05f, 0.10f);

        stairPrefab.transform.localScale = new Vector3(scale, 0.05f, 0);

        if (twoStair <= 5)
        {
            twoStairCoins = true;
            
            Instantiate(stairPrefab, new Vector3(25f, .25f, 0), stairPrefab.transform.rotation);
            Instantiate(stairPrefab, new Vector3(32f, .25f, 0), stairPrefab.transform.rotation);
        }
        else
        {
            twoStairCoins = false;
            Instantiate(stairPrefab, new Vector3(23f, 1.25f, 0), stairPrefab.transform.rotation);
            Instantiate(stairPrefab, new Vector3(30f, 1.25f, 0), stairPrefab.transform.rotation);
        }

        stairGapLimit = Random.Range(5f, 10f);
    }

    void spawnCoins(int numCoins)
    {
        for (int i = 0; i < numCoins; i++)
        {
            if (twoStairCoins)
            {
                Instantiate(coinPrefab, new Vector3(Random.Range(20, 40), Random.Range(-0.75f + 2.5f, 0.75f + 2.5f), 0), coinPrefab.transform.rotation);
                Instantiate(coinPrefab, new Vector3(Random.Range(15, 30), Random.Range(0.25f + 2.5f, 0.75f + 2.5f), 0), coinPrefab.transform.rotation);
            }
            else
            {
                Instantiate(coinPrefab, new Vector3(Random.Range(20, 40), Random.Range(-0.75f + 2.5f, 0.75f + 2.5f), 0), coinPrefab.transform.rotation);
                Instantiate(coinPrefab, new Vector3(Random.Range(15, 30), Random.Range(-1.75f + 2.5f, -1.25f + 2.5f), 0), coinPrefab.transform.rotation);
            }
        }
    }

    void spawnBlocks()
    {
        int twoBlock = Random.Range(1, 10);

        float posY = Random.Range(0f, 3f);

        float scale = Random.Range(0.050f, 0.1f);

        blockPrefab.transform.localScale = new Vector3(scale, 0.0125f, 0);

        if (twoBlock <= 5)
        {
            Instantiate(blockPrefab, new Vector3(11.5f, posY, 0), blockPrefab.transform.rotation);
            Instantiate(blockPrefab, new Vector3(17.5f, posY + 1f, 0), blockPrefab.transform.rotation);
        }
        else
        {
            Instantiate(blockPrefab, new Vector3(11.5f, posY, 0), blockPrefab.transform.rotation);
        }
        
        blockGapLimit = Random.Range(3f, 9f);
    }

    void spawnCrates()
    {
        float scale = Random.Range(0.05f, 0.075f);

        int tntSpawn = Random.Range(1, 10);

        if (tntSpawn <= 3)
        {
            tntPrefab.transform.localScale = new Vector3(scale, scale, 0);
            Instantiate(tntPrefab, new Vector3(7f, 5f, 0), tntPrefab.transform.rotation);
            
        }

        else {

            cratePrefab.transform.localScale = new Vector3(scale, scale, 0);
            Instantiate(cratePrefab, new Vector3(7f, 5f, 0), cratePrefab.transform.rotation);
        }

        crateGapLimit = Random.Range(1f, 10f);

    }

    void spawnPlatform() {

        Instantiate(platformPrefab, new Vector3(10f, 2.1f, 0), platformPrefab.transform.rotation);
        platformGapLimit = Random.Range(1f, 3f);
    }

    void spawnLava()
    {
       Instantiate(lavaPrefab, new Vector3(10f, -1.5f, 0), lavaPrefab.transform.rotation);  
    }
}
