using System.Threading;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class NetworkManager : Photon.MonoBehaviour
{
	public string PrefabToInstantiate = "Pawn";
	public bool HideUI = false;
	public int GuiSpace = 0;    // inspector value
	private Transform spawnPoint;
	
	private GameObject lastInstantiateMine;
	private GameObject lastInstantiateScene;
	private int prefix;

	IEnumerator OnLeftRoom()
	{
		PhotonNetwork.LoadLevel("_mainMenu");
		
		//Wait untill Photon is properly disconnected (empty room, and connected back to main server)
		while(PhotonNetwork.room!=null || PhotonNetwork.connected==false)
			yield return 0;
		

		
	}
		
//	void OnJoinedLobby()
//	{
//		Debug.Log ("Lobby Joined");
//		PhotonNetwork.JoinRandomRoom();
//	}
//	void OnPhotonRandomJoinFailed(){
//		Debug.Log ("Join Failed: Creating new room...");
//		PhotonNetwork.CreateRoom (null);
//	}

	void Start()
	{

	}

	void OnJoinedRoom(){
//		Application.LoadLevel ("_networkDebug");
//		PhotonNetwork.LoadLevel ("_networkDebug");
		spawnPoint = GameObject.FindGameObjectWithTag ("SpawnPoint").transform;
		Debug.Log ("Room Joined!");
		GameObject Pawn = PhotonNetwork.Instantiate (PrefabToInstantiate, 
		                                                    spawnPoint.transform.position, 
		                                                    spawnPoint.transform.rotation, 0);
		Camera.main.GetComponent<CameraFollow> ().objectToFollow = Pawn;
	}
//	void OnCreatedRoom(){
//		Debug.Log ("Room Created, Joining.");
//	}

	public void OnGUI()
	{
		if (HideUI)
		{
			return;
		}
		GUILayout.Space(GuiSpace);
		
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
		
//		if (!PhotonNetwork.connected)
//		{
//			if (GUILayout.Button("Connect"))
//			{
//				PhotonNetwork.ConnectUsingSettings("1");
//			}
//		}
//		else
//		{
			if (GUILayout.Button("Disconnect"))
			{
				PhotonNetwork.Disconnect();
			}
//		}
	}
}