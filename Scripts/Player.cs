using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _input;

    public float Speed;
    public GameObject BulletPrefab;
    public Transform GunPoint;
    public GameObject BloodPrefab;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.up = (MouseUtils.GetMousePosition2d() - (Vector2)transform.position).normalized;
        _rigidbody.velocity = _input.normalized * Speed;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(BulletPrefab, GunPoint.position, transform.rotation);
    }

    public void Die()
    {
        Instantiate(BloodPrefab, transform.position, Quaternion.identity);
        FindObjectOfType<TMP_Text>().enabled = true;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            Die();
        }
    }
}
