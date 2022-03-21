using UnityEngine;

enum CAMERA_MOVING_STATES { right, left, up, down, forward, back, none }

public class CameraControls : MonoBehaviour
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private GameObject target;
	CAMERA_MOVING_STATES CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.none;

	private void Update()
	{
		mainCamera.transform.LookAt(target.transform);

		if (CAMERA_MOVING_STATE == CAMERA_MOVING_STATES.right)
			OnMoveRight();

		if (CAMERA_MOVING_STATE == CAMERA_MOVING_STATES.left)
			OnMoveLeft();


		if (CAMERA_MOVING_STATE == CAMERA_MOVING_STATES.up)
			OnMoveUp();

		if (CAMERA_MOVING_STATE == CAMERA_MOVING_STATES.down)
			OnMoveDown();



		if (CAMERA_MOVING_STATE == CAMERA_MOVING_STATES.forward)
			OnMoveForward();

		if (CAMERA_MOVING_STATE == CAMERA_MOVING_STATES.back)
			OnMoveBack();
	}

	public void OnRightDown() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.right; } 
	public void OnRightUp() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.none; }

	public void OnLeftDown() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.left; }
	public void OnLeftUp() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.none; }



	public void OnUpDown() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.up;  }
	public void OnUpisUp() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.none; }

	public void OnDownisDown() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.down; }
	public void OnDownisUp() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.none; }



	public void OnForwardDown() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.forward; }
	public void OnForwardUp() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.none; }

	public void OnBackDown() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.back; }
	public void OnBackUp() { CAMERA_MOVING_STATE = CAMERA_MOVING_STATES.none; }







	// camera moves
	private void OnMoveUp()
	{
		//mainCamera.transform.Translate(Vector3.up, Space.Self);
		mainCamera.transform.RotateAround(transform.position, Vector3.right, 1);
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
