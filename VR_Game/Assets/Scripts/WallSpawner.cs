using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.XR;

public class WallSpawner : MonoBehaviour
{
    private InputDevice targetDevice;
    //private Animation anim;
    public GameObject wall;
    public GameObject cam;
    public GameObject player;
    public float spawnDistance;
    private bool isWallBuilt = false;

    public bool isEarth = false;
    
    public List<GameObject> objects;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }
    private void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool secondaryButtonValue);
        Debug.Log("Entrato nell if : " + isEarth);
        
        if (secondaryButtonValue == true && isWallBuilt == false && isEarth == true )
        {
            MagicWall();
        }
    }
    
    public void MagicWall()
    {
        
            float dirX = cam.transform.forward.x;
            float dirY = player.transform.forward.y;
            float dirZ = cam.transform.forward.z * spawnDistance;

            Vector3 playerPos = cam.transform.position;
            Vector3 playerDirection = new Vector3(dirX, dirY, dirZ); //player.transform.forward; 
            Quaternion playerRotation = cam.transform.rotation;
            Vector3 spawnPos = playerPos + playerDirection;
            if (isWallBuilt == false)
            {
                var cloneWall = Instantiate(wall, spawnPos, playerRotation);
                Debug.Log("Coordinate Camera " + cam.transform.forward.x + " -- " + player.transform.forward.y +
                          " -- " + cam.transform.forward.z * spawnDistance);
                Debug.Log("Muro. " + cloneWall.transform.position.x + " -- " + cloneWall.transform.position.y + " -- " +
                          cloneWall.transform.position.z);
                isWallBuilt = true;
                Destroy(cloneWall, 7.0f);
            }
            Invoke("ResetWallCounter", 7.0f);
    }

    private void ResetWallCounter()
    {
       // Destroy(wall);
        isWallBuilt = false;
        
    }
    
}