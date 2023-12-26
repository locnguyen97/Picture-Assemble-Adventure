using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectMoveByDrag : MonoBehaviour
{
    [SerializeField] List<GameObject> particleVFXs;

    private Vector3 startPos;
    private Transform target;

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void PickUp()
    {
        //transform.rotation = new Quaternion(0,0,0,0);
    }

    public void CheckOnMouseUp()
    {
        //transform.position = startPos;
        if (target)
        {
            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
            Destroy(explosion, .75f);
            transform.position = target.position;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].RemoveObject(gameObject);
            target.GetComponent<SpriteRenderer>().enabled = true;
            Destroy(gameObject);
            GameManager.Instance.CheckLevelUp();
        }
        else
        {
            transform.position = startPos;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name == collision.gameObject.name)
        {
            target = collision.transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.name == collision.gameObject.name)
        {
            target = null;
        }
    }
}
