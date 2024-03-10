using UnityEngine;
using TMPro;

public class VegetableCollision : MonoBehaviour
{
    public GameObject[] vegetables;
    public TMP_Text scoreText;

    private bool spawned = false;
    public int[] mergePoints;
    private float lastMergeTime;

   
    public static int score = 0;

    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();

        mergePoints = new int[vegetables.Length];
        mergePoints[0] = 5;
        mergePoints[1] = 10;
        mergePoints[2] = 15;
        mergePoints[3] = 20;
        mergePoints[4] = 25;
        mergePoints[5] = 30;
        mergePoints[6] = 35;
        mergePoints[7] = 40;
        mergePoints[8] = 45;
        mergePoints[9] = 50;
        mergePoints[10] = 55;

    }

    void Update()
    {
        if (transform.position.y > 50f || transform.position.y < -50f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (Time.time - lastMergeTime > 1f)
        {
            if (col.gameObject.CompareTag(gameObject.tag) && !spawned)
            {
                GameObject veggie1 = gameObject;
                GameObject veggie2 = col.gameObject;

                int veggie1Index = GetVegetableIndex(veggie1.tag);
                int veggie2Index = GetVegetableIndex(veggie2.tag);

                GameObject newVeg = SpawnMergedVeggie(veggie1, veggie2);

                int newVeggieIndex = GetVegetableIndex(newVeg.tag);

                
                score += mergePoints[veggie1Index] + mergePoints[veggie2Index];

                
                scoreText.text = score.ToString();
                AudioManager.PlayMergeSound();
                lastMergeTime = Time.time;

            }
        }

        if (col.transform.position.y > 50f || col.transform.position.y < -50f)
        {
            Destroy(col.gameObject);
        }
    }

    GameObject SpawnMergedVeggie(GameObject veggie1, GameObject veggie2)
    {
        int veggie1Index = GetVegetableIndex(veggie1.tag);
        int nextIndex = (veggie1Index + 1) % vegetables.Length;

        GameObject nextVeggie = vegetables[nextIndex];

        Vector2 position = (veggie1.transform.position + veggie2.transform.position) / 2;

        GameObject newVeg = Instantiate(nextVeggie, position, Quaternion.identity);

        veggie1.transform.position = Vector2.one * 100;
        veggie2.transform.position = Vector2.one * 100;

        return newVeg;
    }

    void LateUpdate()
    {
        spawned = false;
    }

    int GetVegetableIndex(string tag)
    {
        for (int i = 0; i < vegetables.Length; i++)
        {
            if (vegetables[i].CompareTag(tag))
            {
                return i;
            }
        }
        return -1;
    }
}