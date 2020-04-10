using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudPariclePrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_cloudPariclePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy!=null)
        {
            return;
        }

        var contactPoint = collision.contacts[0];
        Debug.DrawLine(contactPoint.point, contactPoint.normal, Color.green, 10, false);
        if(contactPoint.normal.y < -0.5)
        {
            Instantiate(_cloudPariclePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
