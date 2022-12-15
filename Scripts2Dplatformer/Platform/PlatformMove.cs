using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove: MonoBehaviour
{
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 nextPos;

    public float speed = 3f;

    [SerializeField] private Transform pltTransform;
    [SerializeField] private Transform transformPos2;

    void Start()
    {
        pos1 = pltTransform.localPosition;
        pos2 = transformPos2.localPosition;
        nextPos = pos2;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        pltTransform.localPosition = Vector3.MoveTowards(pltTransform.localPosition, nextPos, speed * Time.deltaTime);

        if (Vector3.Distance(pltTransform.localPosition, nextPos) <= 0.1)
        {
            nextPos = nextPos != pos1 ? pos1 : pos2;
        }
    }

}
