using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace Tanks.TankControllers
{
	/// <summary>
	/// Input module that handles keyboard controls
	/// </summary>
	public class TankKeyboardInput : TankInputModule
	{
		protected override bool DoFiringInput()
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				return false;
			}

			// Mouse pos
			if (Input.mousePresent)
			{
				bool mousePressed = Input.GetMouseButton(0);

				if (isActiveModule || mousePressed)
				{
					Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
					float hitDist;
					RaycastHit hit;
					if (Physics.Raycast(mouseRay, out hit, float.PositiveInfinity, m_GroundLayerMask))
					{
						SetDesiredFirePosition(hit.point);
					}
					else if (m_FloorPlane.Raycast(mouseRay, out hitDist))
					{
						SetDesiredFirePosition(mouseRay.GetPoint(hitDist));
					}
				}
				SetFireIsHeld(mousePressed);

				return mousePressed;
			}

			return false;
		}

		protected override void OnBecomesActive()
		{
			OnInputMethodChanged(false);
		}

		protected override bool DoMovementInput()
		{
            //float y = 0;
            //float x = 0;

            //if (Input.GetKey(KeyCode.A))
            //{
            //    x = -1;
            //}
            //else if (Input.GetKey(KeyCode.D))
            //{
            //    x = 1;
            //}
            //if (Input.GetKey(KeyCode.W))
            //{
            //    y = 1;
            //}
            //else if (Input.GetKey(KeyCode.S))
            //{
            //    y = -1;
            //}

            float y = Input.GetAxisRaw("Vertical");
            // Debug.Log("Y: " + y);
            float x = Input.GetAxisRaw("Horizontal");
            // Debug.Log("X: " + x);

            Vector3 cameraDirection = new Vector3(x, y, 0);

			if (cameraDirection.sqrMagnitude > 0.01f)
			{
				// Get camera relative vectors
				Vector3 worldUp = Camera.main.transform.TransformDirection(Vector3.up);
				worldUp.y = 0;
				worldUp.Normalize();
				Vector3 worldRight = Camera.main.transform.TransformDirection(Vector3.right);
				worldRight.y = 0;
				worldRight.Normalize();

				Vector3 worldDirection = worldUp * y + worldRight * x;
				Vector2 desiredDir = new Vector2(worldDirection.x, worldDirection.z);
				if (desiredDir.magnitude > 1)
				{
					desiredDir.Normalize();
				}
				SetDesiredMovementDirection(desiredDir);

				return true;
			}

			return false;
		}
	}
}