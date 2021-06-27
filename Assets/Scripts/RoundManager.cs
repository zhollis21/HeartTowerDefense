using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance;
    public GameObject RedHeart;
    public GameObject BlueHeart;
    public GameObject GreenHeart;
    public GameObject YellowHeart;
    public GameObject PinkHeart;

    private Queue<KeyValuePair<GameObject, float>> _roundHeartsAndTimes;
    private float _nextSpawnTime;

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
        if (_roundHeartsAndTimes != null && _roundHeartsAndTimes.Count > 0 && Time.time > _nextSpawnTime)
        {
            var nextHeartAndTime = _roundHeartsAndTimes.Dequeue();

            Instantiate(nextHeartAndTime.Key);

            // Set the next spawn time by adding the wait time to the current time
            _nextSpawnTime = Time.time + nextHeartAndTime.Value;
        }
    }

    public bool IsRoundPlaying()
    {
        return _roundHeartsAndTimes != null && _roundHeartsAndTimes.Count > 0;
    }

    public void PlayRound(int Round)
    {
        var listOfHearts = GetRoundHearts(Round);

        if (listOfHearts != null)
        {
            _roundHeartsAndTimes = new Queue<KeyValuePair<GameObject, float>>(listOfHearts);
        }
    }

    private List<KeyValuePair<GameObject, float>> GetRoundHearts(int round)
    {
        switch (round)
        {
            case 1:
                return GetRound1Hearts();
            case 2:
                return GetRound2Hearts();
            case 3:
                return GetRound3Hearts();
            case 4:
                return GetRound4Hearts();
            case 5:
                return GetRound5Hearts();
            case 6:
                return GetRound6Hearts();
            case 7:
                return GetRound7Hearts();
            case 8:
                return GetRound8Hearts();
            case 9:
                return GetRound9Hearts();
            case 10:
                return GetRound10Hearts();
            default:
                Debug.LogError($"No get round function for round #{round}");
                return null;
        }
    }

    private List<KeyValuePair<GameObject, float>> BuildListOfHearts(GameObject heart, float timeBetweenHearts, int count)
    {
        var heartsAndTimes = new List<KeyValuePair<GameObject, float>>();

        for (int i = 0; i < count; i++)
        {
            heartsAndTimes.Add(new KeyValuePair<GameObject, float>(heart, timeBetweenHearts));
        }

        return heartsAndTimes;
    }

    private List<KeyValuePair<GameObject, float>> GetRound1Hearts()
    {
        return BuildListOfHearts(RedHeart, 1, 20);
    }

    private List<KeyValuePair<GameObject, float>> GetRound2Hearts()
    {
        return BuildListOfHearts(RedHeart, .5f, 35);
    }

    private List<KeyValuePair<GameObject, float>> GetRound3Hearts()
    {
        var heartList = BuildListOfHearts(RedHeart, .5f, 10);
        heartList.AddRange(BuildListOfHearts(BlueHeart, .5f, 5));
        heartList.AddRange(BuildListOfHearts(RedHeart, .5f, 15));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound4Hearts()
    {
        var heartList = BuildListOfHearts(RedHeart, .5f, 25);
        heartList.AddRange(BuildListOfHearts(BlueHeart, .2f, 18));
        heartList.AddRange(BuildListOfHearts(RedHeart, .2f, 10));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound5Hearts()
    {
        var heartList = BuildListOfHearts(BlueHeart, .5f, 12);
        heartList.AddRange(BuildListOfHearts(RedHeart, .5f, 5));
        heartList.AddRange(BuildListOfHearts(BlueHeart, .5f, 15));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound6Hearts()
    {
        var heartList = BuildListOfHearts(GreenHeart, .5f, 4);
        heartList.AddRange(BuildListOfHearts(RedHeart, .1f, 15));
        heartList.AddRange(BuildListOfHearts(BlueHeart, .25f, 15));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound7Hearts()
    {
        var heartList = BuildListOfHearts(BlueHeart, .5f, 10);
        heartList.AddRange(BuildListOfHearts(GreenHeart, 1, 5));
        heartList.AddRange(BuildListOfHearts(RedHeart, .2f, 20));
        heartList.AddRange(BuildListOfHearts(BlueHeart, .2f, 10));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound8Hearts()
    {
        var heartList = BuildListOfHearts(BlueHeart, .5f, 20);
        heartList.AddRange(BuildListOfHearts(GreenHeart, .5f, 2));
        heartList.AddRange(BuildListOfHearts(RedHeart, .1f, 10));
        heartList.AddRange(BuildListOfHearts(GreenHeart, .75f, 12));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound9Hearts()
    {
        return BuildListOfHearts(GreenHeart, .5f, 30);
    }

    private List<KeyValuePair<GameObject, float>> GetRound10Hearts()
    {
        var heartList = BuildListOfHearts(BlueHeart, .5f, 80);
        heartList.AddRange(BuildListOfHearts(BlueHeart, .05f, 22));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound11Hearts()
    {
        var heartList = BuildListOfHearts(YellowHeart, .5f, 3);
        heartList.AddRange(BuildListOfHearts(GreenHeart, .5f, 12));
        heartList.AddRange(BuildListOfHearts(BlueHeart, .25f, 10));
        heartList.AddRange(BuildListOfHearts(RedHeart, .1f, 10));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound12Hearts()
    {
        var heartList = BuildListOfHearts(GreenHeart, 1, 10);
        heartList.AddRange(BuildListOfHearts(BlueHeart, .5f, 15));
        heartList.AddRange(BuildListOfHearts(YellowHeart, 1.5f, 5));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound13Hearts()
    {
        var heartList = BuildListOfHearts(BlueHeart, .5f, 20);
        heartList.AddRange(BuildListOfHearts(GreenHeart, .5f, 2));
        heartList.AddRange(BuildListOfHearts(RedHeart, .1f, 10));
        heartList.AddRange(BuildListOfHearts(GreenHeart, .75f, 12));

        return heartList;
    }

    private List<KeyValuePair<GameObject, float>> GetRound14Hearts()
    {
        return BuildListOfHearts(GreenHeart, .5f, 30);
    }

    private List<KeyValuePair<GameObject, float>> GetRound15Hearts()
    {
        var heartList = BuildListOfHearts(BlueHeart, .5f, 80);
        heartList.AddRange(BuildListOfHearts(BlueHeart, .05f, 22));

        return heartList;
    }
}
