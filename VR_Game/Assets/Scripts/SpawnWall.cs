using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpawnWall : MonoBehaviour
{
	private Animation anim;
   	public GameObject wall;
    public GameObject player;
    public float spawnDistance;

    private void Update()
    {
         //if (Input.GetMouseButtonDown(0))
        //{
        if (InputFeatureUsage.primaryButton)
        	print("Bottone premuto");
            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            Quaternion playerRotation = player.transform.rotation;

            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

            Instantiate(wall, spawnPos, playerRotation);
            anim.Play();
        //}
    }
}
