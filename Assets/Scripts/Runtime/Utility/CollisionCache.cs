using System.Collections.Generic;
using UnityEngine;

public class CollisionCache : MonoBehaviour
{
    private readonly HashSet<GameObject> _gameObjects = new HashSet<GameObject>();
    public IEnumerable<GameObject> GameObjects => _gameObjects;

    private void OnTriggerEnter(Collider collision)
    {
        _gameObjects.Add(collision.gameObject);
    }

    private void OnTriggerExit(Collider collision)
    {
        _gameObjects.Remove(collision.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _gameObjects.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        _gameObjects.Remove(collision.gameObject);
    }
}