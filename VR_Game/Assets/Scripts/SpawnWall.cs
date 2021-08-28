using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpawnWall : MonoBehaviour
{
	private InputDevice targetDevice;
	//private Animation anim;
   	public GameObject wall;
    public GameObject player;
    public float spawnDistance;
    public bool isWallBuilt = true;

    
    void Start()
    {
	    List<InputDevice> devices = new List<InputDevice>();
	    InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
	    InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics,devices);

	    foreach (var item in devices)
	    {
		    Debug.Log(item.name + item.characteristics);
	    }

	    if (devices.Count > 0)
	    {
		    targetDevice = devices[0];
	    }

	    StartCoroutine(Wait());
    }
    private void Update()
    {
	    targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
		
	    if (triggerValue > 0.1f && isWallBuilt == true)
	    {
		    isWallBuilt = false;
		    MagicWall();
		    
	    }
	    
    }

    IEnumerator Wait()
    {
	    yield return new WaitForSeconds(5f);
    }
    private void MagicWall()
    {
			
		    Vector3 playerPos = player.transform.position;
		    Vector3 playerDirection = player.transform.forward;
		    Quaternion playerRotation = player.transform.rotation;
		    Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
		    Debug.Log("Grilletto Premuto!!!");
		    
		    Instantiate(wall, spawnPos, playerRotation);
		    Wait();
		    isWallBuilt = true;
		    //anim.Play();

    }
}
