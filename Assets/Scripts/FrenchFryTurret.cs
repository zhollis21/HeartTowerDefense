using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenchFryTurret : MonoBehaviour
{
    public int Range = 5;

    private Transform _radiusTransform;
    private CircleCollider2D _radiusCollider;

    // Start is called before the first frame update
    void Start()
    {
        _radiusTransform = transform.Find("Radius");
        _radiusTransform.localScale = new Vector3(Range, Range);

        _radiusCollider = GetComponent<CircleCollider2D>();
        _radiusCollider.radius = Range / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        RotateTowards(other.transform.position);
    }

    private void RotateTowards(Vector2 target)
    {
        var offset = -90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
