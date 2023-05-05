using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    //private
    private float spawnRate = 1.0f;
    private int score;
    private GameManager gamuM;
    //public
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public int pointValue;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);

        gamuM = GetObject.Find("Game Manager").GetComponent<GameManager>();
    }

    IEnumerator SpawnTarget() 
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
                int index = Random.Range(0, targets.Count);
            
            Instantiate(targets[index]);
            
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    private void OnMouseDown()
    {
        gamuM.UpdateScore(5);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
