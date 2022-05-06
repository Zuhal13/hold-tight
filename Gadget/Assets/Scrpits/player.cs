using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class player : MonoBehaviour
{
    public GameObject rMagnet, lMagnet;

    float rStartPos, lStartPos;
    float rLastPos,lLastPos;
    float rTimer, lTimer;


    bool canRightMove =true;
    bool canLefttMove = false;

    private void Start()
    {
        rStartPos = rMagnet.transform.position.y;
        lStartPos = lMagnet.transform.position.y;

    }
    private void Update()
    {
        rightMove();
        leftMove();

        if (Input.GetMouseButtonDown(0) && canRightMove)
        {
            lTimer = 0;
            canRightMove = false;
            rLastPos = rMagnet.transform.position.y;
            lMagnet.transform.DOMoveY(rLastPos, 0.1f).OnComplete(() => changeTurn(rStartPos,rMagnet));


        }
        else if (Input.GetMouseButtonDown(0) && !canRightMove)
        {
            rTimer = 0;
            canRightMove = true;
            lLastPos = lMagnet.transform.position.y;
            rMagnet.transform.DOMoveY(lLastPos, 0.1f).OnComplete(() => changeTurn(lStartPos,lMagnet));

        }
    }
    
   
    void rightMove()
    {
        if (canRightMove&&!canLefttMove)
        {
            rTimer += 0.005f;
            rMagnet.transform.position = new Vector3(rMagnet.transform.position.x, rStartPos + Mathf.PingPong(rTimer, 1), rMagnet.transform.position.z);

        }
       
    }
    void leftMove()
    {
        if (!canRightMove&&canLefttMove)
        {
            lTimer += 0.005f;
            lMagnet.transform.position = new Vector3(lMagnet.transform.position.x, lStartPos + Mathf.PingPong(lTimer, 1), lMagnet.transform.position.z);

        }
    }

    void changeTurn(float whichPos, GameObject magnet)
    {
        canLefttMove = !canLefttMove;
        whichPos = magnet.transform.position.y;

    }
}