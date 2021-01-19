using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    #region Variables
    //Movement
    public float speed;

    //Auxiliar
    private bool moveRight;
    private float targetRight;
    private float targetLeft;
    public float leeway;
    #endregion

    #region Unity callbacks
    private void Start()
    {
        targetRight = transform.localPosition.x + leeway;
        targetLeft = transform.localPosition.x - leeway;
    }
    private void Update()
    {
        if (GameManager.sharedInstance.paused) return;
        if (GameManager.sharedInstance.gameOver) return;
        if (moveRight)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.localPosition.x >= targetRight)
            moveRight = false;

        if (transform.localPosition.x <= targetLeft)
            moveRight = true;
    }
    #endregion
}
