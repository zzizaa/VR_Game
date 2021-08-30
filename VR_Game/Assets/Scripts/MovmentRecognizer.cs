using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovmentRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    
    public float newPositionThresholdDistance = 0.5f;
    public GameObject debugCubePrefab;
    
    private bool isMoving = false;
    private List<Vector3> positionsList = new List<Vector3>();
  
    /// <summary>
    /// ///////////////////
    /// </summary>
    public Transform movementSource;
    
    
    void Start()
    {
 
    }
    
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
       
        //Start The Movement
        if (!isMoving && isPressed)
        {
            StartMovement();
        }
        //Ending The Movement
        else if (isMoving && !isPressed)
        {
            EndMovement();
        }
        else if (isMoving && isPressed)
        {
            UpdateMovement();
        }
    }

    void StartMovement()
    {
        Debug.Log("Start Movement");
        isMoving = true;
        positionsList.Clear();
        positionsList.Add(movementSource.position);
        if (debugCubePrefab)
        {
            Destroy(Instantiate(debugCubePrefab,movementSource.position,Quaternion.identity),3);
        }
        
    }

    void EndMovement()
    {
        Debug.Log("Update Movement");
        isMoving = false;
    }

    void UpdateMovement()
    {
        Debug.Log("Update Movement");
        Vector3 lastPosition = positionsList[positionsList.Count - 1]; 
        if (Vector3.Distance(movementSource.position, lastPosition) > newPositionThresholdDistance)
        {
            positionsList.Add(movementSource.position);
            if (debugCubePrefab)
            {
                Destroy(Instantiate(debugCubePrefab, movementSource.position, Quaternion.identity), 3);
            }
        }
    }
}
