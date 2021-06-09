using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public enum HeartType { Red, Blue, Green, Yellow }

    public HeartType Type;
    public int HitPoints;
    public float Speed;

    private List<Vector3> _mapPoints;
    private int _pointIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        _mapPoints = GameManager.Instance.CurrentMap.PathPoints;
        transform.position = _mapPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _mapPoints[_pointIndex], Time.deltaTime * Speed * 2);

        if (transform.position == _mapPoints[_pointIndex])
        {
            _pointIndex++;

            if (_pointIndex == _mapPoints.Count)
            {
                GameManager.Instance.Lives--;
                Destroy(this.gameObject);
            }
        }
    }

    void TakeDamage(int amount)
    {
        HitPoints -= amount;

        if (HitPoints < 1)
        {
            Destroy(gameObject);
        }
    }
}
