using UnityEngine;

enum CAMERA_MOVING_STATES { right, left, up, down, forward, back, none }

public class CameraControls : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private GameObject target;
	CAMERA_MOVING_STATES camera_moving_state = CAMERA_MOVING_STATES.none;

	private void Update()
	{

		mainCamera.transform.LookAt(target.transform);
        switch (camera_moving_state)
        {
			case CAMERA_MOVING_STATES.right:
				OnMoveRight();
				break;
			case CAMERA_MOVING_STATES.left:
				OnMoveLeft();
				break;
			case CAMERA_MOVING_STATES.up:
				OnMoveUp();
				break;
			case CAMERA_MOVING_STATES.down:
				OnMoveDown();
				break;
			case CAMERA_MOVING_STATES.forward:
				OnMoveForward();
				break;
			case CAMERA_MOVING_STATES.back:
				OnMoveBack();
				break;
			default:
				camera_moving_state = CAMERA_MOVING_STATES.none;
				break;
        }
	}

	public void OnRightDown() { camera_moving_state = CAMERA_MOVING_STATES.right; } 
	public void OnLeftDown() { camera_moving_state = CAMERA_MOVING_STATES.left; }
	public void OnUpDown() { camera_moving_state = CAMERA_MOVING_STATES.up; }
	public void OnDownisDown() { camera_moving_state = CAMERA_MOVING_STATES.down; }
	public void OnForwardDown() { camera_moving_state = CAMERA_MOVING_STATES.forward; }
	public void OnBackDown() { camera_moving_state = CAMERA_MOVING_STATES.back; }
	public void OnCameraPointersUp() { camera_moving_state = CAMERA_MOVING_STATES.none; }




	// camera moves
	private void OnMoveUp()
	{
		//mainCamera.transform.Translate(Vector3.up, Space.Self);
		mainCamera.transform.RotateAround(target.transform.position, Vector3.right, 1);
	}

	private void OnMoveDown()
	{
		// mainCamera.transform.Translate(Vector3.down, Space.Self);
		mainCamera.transform.RotateAround(target.transform.position, Vector3.right, -1);

	}

	private void OnMoveRight()
	{
		mainCamera.transform.RotateAround(target.transform.position, Vector3.up, 1);
	}

	private void OnMoveLeft()
	{
		mainCamera.transform.RotateAround(target.transform.position, Vector3.up, -1);
	}


	private void OnMoveForward()
	{
		if(Vector3.Distance(mainCamera.transform.position, target.transform.position) > 1 )
			mainCamera.transform.Translate(new Vector3(0,0, 0.03f), Space.Self);
	  
	}

	private void OnMoveBack()
	{
		mainCamera.transform.Translate(new Vector3(0, 0, -0.03f), Space.Self);
	   
	}
	
}
