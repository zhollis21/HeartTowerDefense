using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public enum HeartType { Red, Blue, Green, Yellow }

    public HeartType Type;
    public List<Sprite> HeartSprites;

    private int _hitPoints;
    private float _speed;
    private int _redHeartEquivalent;
    private List<Vector3> _mapPoints;
    private int _pointIndex = 1;
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mapPoints = GameManager.Instance.CurrentMap.PathPoints;
        transform.position = _mapPoints[0];
        SetHeartStatsByCurrentType();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _mapPoints[_pointIndex], Time.deltaTime * _speed * 2);

        if (transform.position == _mapPoints[_pointIndex])
        {
            _pointIndex++;

            if (_pointIndex == _mapPoints.Count)
            {
                GameManager.Instance.Lives -= _redHeartEquivalent;
                Destroy(gameObject);
            }
        }
    }

    void TakeDamage(int amount)
    {
        _hitPoints -= amount;

        if (_hitPoints < 1)
        {
            SpawnHearts(Mathf.Abs(_hitPoints));
        }
    }

    private void SpawnHearts(int carryOverDamage)
    {
        switch (Type)
        {
            case HeartType.Red:
                Destroy(gameObject);
                break;
            case HeartType.Blue:
            case HeartType.Green:
            case HeartType.Yellow:
                Type -= 1;
                SetHeartStatsByCurrentType();
                break;
        }

        if (carryOverDamage > 0)
        {
            TakeDamage(carryOverDamage);
        }
    }

    private void SetHeartStatsByCurrentType()
    {
        switch (Type)
        {
            case HeartType.Red:
                _speed = 1;
                _hitPoints = 1;
                _redHeartEquivalent = 1;
                _spriteRenderer.sprite = HeartSpriteManager.Instance.GetHeartSprite(Type);
                break;

            case HeartType.Blue:
                _speed = 1.4f;
                _hitPoints = 1;
                _redHeartEquivalent = 2;
                _spriteRenderer.sprite = HeartSpriteManager.Instance.GetHeartSprite(Type);
                break;

            case HeartType.Green:
                _speed = 1.8f;
                _hitPoints = 1;
                _redHeartEquivalent = 3;
                _spriteRenderer.sprite = HeartSpriteManager.Instance.GetHeartSprite(Type);
                break;

            case HeartType.Yellow:
                _speed = 3.2f;
                _hitPoints = 1;
                _redHeartEquivalent = 4;
                _spriteRenderer.sprite = HeartSpriteManager.Instance.GetHeartSprite(Type);
                break;
        }
    }
}
