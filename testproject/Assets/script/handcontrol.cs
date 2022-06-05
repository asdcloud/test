using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class handcontrol : MonoBehaviour
{
    [SerializeField] public float handSpeed = 0.2f;
    private float handInput;
    public CollisionDetectionMode collisionDetectionMode;

    public Rigidbody2D rigidBody2D;
    public void AddTorqueImpulse(float angularChangeInDegrees)
    {
        var body = GetComponent<Rigidbody2D>();
        var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * body.inertia;

        body.AddTorque(impulse, ForceMode2D.Impulse);
    }

    void start() {
        rigidBody2D = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        handInput = Input.GetAxisRaw("Hand"); 
        //按鈕是否被按下s
        if(handInput == 1)
        {
            AddTorqueImpulse(handSpeed);
            //rigidBody2D.rotation += handSpeed;
            //transform.Rotate(new Vector3(0, 0, handSpeed));
        }else if (handInput == -1) {
            AddTorqueImpulse(handSpeed * handInput);
            //rigidBody2D.rotation += handSpeed * handInput;
            //transform.Rotate(new Vector3(0, 0, handSpeed * handInput));
        }
    }
}
