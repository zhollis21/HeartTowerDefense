using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FrenchFryTurret : MonoBehaviour
{
    public int Range = 5;
    public Bullet FrenchFryBullet;
    public float AttackSpeed = 1;

    private Transform _radiusTransform;
    private CircleCollider2D _radiusCollider;
    private readonly List<GameObject> _targets = new List<GameObject>();
    private float _timeOfLastAttack;

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
        var target = _targets.FirstOrDefault();

        if (target != null)
        {
            Attack(target);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _targets.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _targets.Remove(other.gameObject);
    }

    private void Attack(GameObject target)
    {
        if ((Time.time - _timeOfLastAttack) > AttackSpeed)
        {
            _timeOfLastAttack = Time.time;

            RotateTowards(target.transform.position);
            Instantiate(FrenchFryBullet, transform.position, transform.rotation);
        }
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
