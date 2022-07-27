using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D _targetJoint2D;
    private BoxCollider2D _boxCollider2D;

    private void Start()
    {
        _targetJoint2D = GetComponent<TargetJoint2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }

        if(collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

    private void Falling()
    {
        _targetJoint2D.enabled = false;
        //_boxCollider2D.isTrigger = true;
    }
}
