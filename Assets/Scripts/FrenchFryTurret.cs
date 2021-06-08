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

    void OnTriggerEnter(Collider other)
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = other.transform.position - transform.position;

        // Rotate the forward vector towards the target direction
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 360, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
