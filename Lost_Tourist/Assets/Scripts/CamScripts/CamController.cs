using UnityEngine;
using System.Collections.Generic;


public class CamController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float minY, maxY;

    Vector2 lastPos;

    [SerializeField]
    Transform underGround, middleGround;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void Update()
    {
        CamLimit();
        //MoveGround();
    }

    void CamLimit()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minY, maxY), transform.position.z);
    }

    void MoveGround()
    {
        Vector2 dist = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        underGround.position += new Vector3(dist.x, dist.y, 0f);
        middleGround.position += new Vector3(dist.x, dist.y, 0f)* .5f;

        lastPos = transform.position;
    }
}
