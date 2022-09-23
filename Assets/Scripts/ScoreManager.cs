using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScore(int scoreVal)
    {
        score += scoreVal;
    }
}
