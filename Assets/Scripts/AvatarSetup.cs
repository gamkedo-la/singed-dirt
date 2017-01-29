// AVATAR SETUP
// made by Christer "McFunkypants" Kaitila for http://gamkedo.club
// a simple way to do an avatar customization screen with swappable parts
// the GUI is rendered in world coordinates and is attached to the tank!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour {

	public bool CurrentlyChoosing = true;

	//public int hatMeshNum = 0;
	public int upperMeshNum = 0;
	public int middleMeshNum = 0;
	public int lowerMeshNum = 0;

	//public GameObject[] hatMeshes;
	public GameObject[] upperMeshes;
	public GameObject[] middleMeshes;
	public GameObject[] lowerMeshes;

	// init
	void Start () {
		// TODO: load choice in playerPrefs
		//hatMeshNum = Random.Range(0,hatMeshes.Length);
		upperMeshNum = Random.Range(0,upperMeshes.Length);
		middleMeshNum = Random.Range(0,middleMeshes.Length);
		lowerMeshNum = Random.Range(0,lowerMeshes.Length);
		updateAvatar();
	}

	public void updateAvatar()
	{
		Debug.Log("updateAvatar " + upperMeshNum + " " + middleMeshNum + " " + lowerMeshNum);
		int meshNum;

		// hide or unhide as appropriate

		/*
		for (meshNum = 0; meshNum < hatMeshes.Length)
		{
			hatMeshes[meshNum].SetActive(meshNum == hatMeshNum);
		}
		*/

		for (meshNum = 0; meshNum < upperMeshes.Length; meshNum++)
		{
			upperMeshes[meshNum].SetActive(meshNum == upperMeshNum);
		}

		for (meshNum = 0; meshNum < middleMeshes.Length; meshNum++)
		{
			middleMeshes[meshNum].SetActive(meshNum == middleMeshNum);
		}

		for (meshNum = 0; meshNum < lowerMeshes.Length; meshNum++)
		{
			lowerMeshes[meshNum].SetActive(meshNum == lowerMeshNum);
		}

	}

	// GUI click events:
	public void next_upper()
	{
		upperMeshNum++;
		if (upperMeshNum > upperMeshes.Length-1)
			upperMeshNum = 0;
		updateAvatar();
	}
	public void prev_upper()
	{
		upperMeshNum--;
		if (upperMeshNum < 0)
			upperMeshNum = upperMeshes.Length-1;
		updateAvatar();
	}
	public void next_middle()
	{
		middleMeshNum++;
		if (middleMeshNum > middleMeshes.Length-1)
			middleMeshNum = 0;
		updateAvatar();
	}
	public void prev_middle()
	{
		middleMeshNum--;
		if (middleMeshNum < 0)
			middleMeshNum = middleMeshes.Length-1;
		updateAvatar();
	}
	public void next_lower()
	{
		lowerMeshNum++;
		if (lowerMeshNum > lowerMeshes.Length-1)
			lowerMeshNum = 0;
		updateAvatar();
	}
	public void prev_lower()
	{
		lowerMeshNum--;
		if (lowerMeshNum < 0)
			lowerMeshNum = lowerMeshes.Length-1;
		updateAvatar();
	}
	public void clickedReady()
	{
		// TODO: save choice in playerPrefs
		gameObject.SetActive(false); // turn the GUI off
	}

}
