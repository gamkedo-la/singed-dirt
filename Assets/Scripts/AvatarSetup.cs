// AVATAR SETUP
// made by Christer "McFunkypants" Kaitila for http://gamkedo.club
// a simple way to do an avatar customization screen with swappable parts
// the GUI is rendered in world coordinates and is attached to the tank!

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarSetup : MonoBehaviour {

	public bool CurrentlyChoosing = true;

	public int hatMeshNum = 0;
	public int upperMeshNum = 0;
	public int middleMeshNum = 0;
	public int lowerMeshNum = 0;

	public GameObject[] hatMeshes;
	public GameObject[] upperMeshes;
	public GameObject[] middleMeshes;
	public GameObject[] lowerMeshes;

	// public player number text object
	public Text player;

	// init
	void Start () {
		// TODO: load choice in playerPrefs

		if (SceneManager.GetActiveScene ().name == "PlayerSetup") {
			hatMeshNum = Random.Range(0,hatMeshes.Length);
			upperMeshNum = Random.Range(0,upperMeshes.Length);
			middleMeshNum = Random.Range(0,middleMeshes.Length);
			lowerMeshNum = Random.Range(0,lowerMeshes.Length);
			updateAvatar();
			ReportReadyToSceneManager ();
		}
	}

	public void updateAvatar()
	{
		// Debug.Log("updateAvatar L:" + lowerMeshNum + " M:" + middleMeshNum + " U:" + upperMeshNum + " H:" + hatMeshNum);
		int meshNum;

		// hide or unhide as appropriate

		for (meshNum = 0; meshNum < hatMeshes.Length; meshNum++)
		{
			hatMeshes[meshNum].SetActive(meshNum == hatMeshNum);
		}

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

	void ReportReadyToSceneManager(){
		PlayerSelectSceneManager.instance.PlayerReportingReady (gameObject);
	}

	void ReportDoneToSceneManager(){
		PlayerSelectSceneManager.instance.PlayerReportingDone (gameObject);
	}

	// Set meshes for players

	public void SetActiveMeshes(int lowerMesh, int middleMesh, int upperMesh, int hatMesh){
		upperMeshNum = upperMesh;
		middleMeshNum = middleMesh;
		lowerMeshNum = lowerMesh;
		hatMeshNum = hatMesh;
	}

	// GUI click events:
	public void next_hat()
	{
		hatMeshNum++;
		if (hatMeshNum > hatMeshes.Length-1)
			hatMeshNum = 0;
		updateAvatar();
	}
	public void prev_hat()
	{
		hatMeshNum--;
		if (hatMeshNum < 0)
			hatMeshNum = hatMeshes.Length-1;
		updateAvatar();
	}
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

		PlayerPrefs.SetInt (player.text + "lowerMeshNum", lowerMeshNum);
		PlayerPrefs.SetInt (player.text + "middleMeshNum", middleMeshNum);
		PlayerPrefs.SetInt (player.text + "upperMeshNum", upperMeshNum);
		PlayerPrefs.SetInt (player.text + "hatMeshNum", hatMeshNum);
		PlayerPrefs.Save ();
		ReportDoneToSceneManager ();
		// Debug.Log ("Done with selection for " + player.text);
		gameObject.SetActive(false); // turn the GUI off
	}

}
