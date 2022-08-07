using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)]
    float speed = 2f;


    enum EnemyTypes {Carlos, Juan, Federico};

    [SerializeField] EnemyTypes enemyType;

    [SerializeField] Transform playerTransfom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (enemyType)
        {
            case EnemyTypes.Carlos:
                RotateAroundPlayer();
                break;

            case EnemyTypes.Juan:
                ChasePlayer();
                break;


            case EnemyTypes.Federico:
                MoveSelected();
                break;
        }

    }

    private void RotateAroundPlayer()
    {
        LookPlayer();
        transform.RotateAround(playerTransfom.position, Vector3.up, 5f * Time.deltaTime);
    }

    private void ChasePlayer()
    {
        LookPlayer();
        Vector3 direction = (playerTransfom.position - transform.position);
        if (direction.magnitude > 2f)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }

    private void MoveSelected()
    {
        //
    }

    private void LookPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(playerTransfom.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.5F * Time.deltaTime);
    }
}
