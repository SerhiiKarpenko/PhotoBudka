using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MODEL_MOVING_STATES { right, left, forward, back, up, down, none }
enum MODEL_ROTATING_STATES { right, left, forward, back, up, down, none }

public class ModelController : MonoBehaviour
{
    [SerializeField] private GameObject myCamera;
    private MODEL_MOVING_STATES model_moving_state = MODEL_MOVING_STATES.none;
    private MODEL_ROTATING_STATES model_rotating_state = MODEL_ROTATING_STATES.none;
    private float speed = 5f;

    private void Update()
    {
        switch (model_rotating_state)
        {
            case MODEL_ROTATING_STATES.right:
                RotateOnYPositive();
                break;
            case MODEL_ROTATING_STATES.left:
                RotateOnYNegative();
                break;
            case MODEL_ROTATING_STATES.up:
                RotateOnXPositive();
                break;
            case MODEL_ROTATING_STATES.down:
                RotateOnXNegative();
                break;
            case MODEL_ROTATING_STATES.forward:
                RotateOnZPositive();
                break;
            case MODEL_ROTATING_STATES.back:
                RotateOnZNegative();
                break;
            default:
                model_rotating_state = MODEL_ROTATING_STATES.none;
                break;
        }

        switch (model_moving_state)
        {
            case MODEL_MOVING_STATES.forward:
                MoveForwad();
                break;
            case MODEL_MOVING_STATES.back:
                MoveBack();
                break;
            case MODEL_MOVING_STATES.right:
                MoveRight();
                break;
            case MODEL_MOVING_STATES.left:
                MoveLeft();
                break;
            case MODEL_MOVING_STATES.up:
                MoveUp();
                break;
            case MODEL_MOVING_STATES.down:
                MoveDown();
                break;
            default:
                model_moving_state = MODEL_MOVING_STATES.none;
                break;
        }
        
    }


    //states Rotating
    public void OnRightRotationDown() { model_rotating_state = MODEL_ROTATING_STATES.right; }
    public void OnLeftRotationDown() { model_rotating_state = MODEL_ROTATING_STATES.left; }
    public void OnUpRotationDown() { model_rotating_state = MODEL_ROTATING_STATES.up; }
    public void OnDownRotationDown() { model_rotating_state = MODEL_ROTATING_STATES.down; }
    public void OnForwardRotationDown() { model_rotating_state = MODEL_ROTATING_STATES.forward; }
    public void OnBackRotationDown() { model_rotating_state = MODEL_ROTATING_STATES.back; }
    public void OnRotationPointerUp() { model_rotating_state = MODEL_ROTATING_STATES.none; }


    //moving states

    public void OnForwadMoveDown() { model_moving_state = MODEL_MOVING_STATES.forward; }
    public void OnBackMoveDown() { model_moving_state = MODEL_MOVING_STATES.back; }
    public void OnRightMoveDown() { model_moving_state = MODEL_MOVING_STATES.right; }
    public void OnLeftmoveDown() { model_moving_state = MODEL_MOVING_STATES.left; }
    public void OnUpmoveDown() { model_moving_state = MODEL_MOVING_STATES.up; }
    public void OnDownmoveDown() { model_moving_state = MODEL_MOVING_STATES.down; }
    public void OnMovePointersUp() { model_moving_state = MODEL_MOVING_STATES.none; }




    //Rotations
    private void RotateOnYPositive()
    {
        transform.RotateAround(transform.localPosition, Vector3.up, 1);
    }

    private void RotateOnYNegative()
    {
        transform.RotateAround(transform.localPosition, Vector3.up, -1);
    }

    private void RotateOnXPositive()
    {
        transform.RotateAround(transform.localPosition, Vector3.right, 1);
    }

    private void RotateOnXNegative()
    {
        transform.RotateAround(transform.localPosition, Vector3.right, -1);
    }

    private void RotateOnZPositive()
    {
        transform.RotateAround(transform.localPosition, Vector3.forward, 1);
    }

    private void RotateOnZNegative()
    {
        transform.RotateAround(transform.localPosition, Vector3.forward, -1);
    }



    // moves can be Translate
    private void MoveForwad()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void MoveBack()
    {
        if(Vector3.Distance(transform.position, myCamera.transform.position) > 2)
            transform.position += Vector3.back * speed * Time.deltaTime;
    }

    private void MoveRight()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void MoveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void MoveUp()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void MoveDown()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}



