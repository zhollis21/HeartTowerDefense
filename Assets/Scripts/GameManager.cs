using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Round;
    public int Lives;
    public int Money;
    public Map CurrentMap;
    public Heart RedHeart;
    public Heart BlueHeart;
    public static GameManager Instance;

    public const int MAX_ROUND = 5;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Round < MAX_ROUND && !RoundManager.Instance.IsRoundPlaying())
        {
            Round++;
            RoundManager.Instance.PlayRound(Round);
        }
    }
}
