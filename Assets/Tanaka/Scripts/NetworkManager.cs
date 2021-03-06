﻿using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {
	PhotonView photonView;
	GameObject train,player;

	void Start ()
	{
		//photonを利用するための初期設定 ロビーを作成して入る？
		PhotonNetwork.ConnectUsingSettings("0.1");
		photonView = GetComponent<PhotonView> ();
	}

	//PhotonNetwork.ConnectUsingSettingsを行うと呼ばれる
	void OnJoinedLobby()
	{
		//ランダムにルームに入る
		PhotonNetwork.JoinRandomRoom();
	}

	//ランダムにルームに入れなかった
	void OnPhotonRandomJoinFailed()
	{
		//部屋を自分で作って入る
		PhotonNetwork.CreateRoom(null);
	}

	//ルームに入室成功
	void OnJoinedRoom()
	{
		/*
		#if UNITY_EDITOR
		photonView.RPC("JoinPCPlayer",PhotonTargets.Others);

		#endif
		*/

		//キャラクター作成
		PlayerMake ();

	}

	void PlayerMake(){
		#if UNITY_EDITOR
		train = PhotonNetwork.Instantiate ("Train",Vector3.zero,Quaternion.identity,0) as GameObject;
		player = PhotonNetwork.Instantiate ("Player",Vector3.zero,Quaternion.identity,0) as GameObject;
		PhotonNetwork.Instantiate ("PC_Camera_rig",Vector3.zero,Quaternion.identity,0);
		GameObject obj1 = player.transform.Find("CardboardMainHack").gameObject;


		//GameObject obj2 =  PhotonNetwork.Instantiate ("PCCamera",Vector3.zero,Quaternion.identity,0)as GameObject;
		//GameManager.Instance.SetPCCamera (obj2);
		#endif

		#if UNITY_IOS
		/*
		player = PhotonNetwork.Instantiate ("Player",Vector3.zero,Quaternion.identity,0) as GameObject;
		player = GameObject.FindGameObjectWithTag("Player");
		GameObject obj1 = player.transform.Find("CardboardMainHack").gameObject;
		GameManager.Instance.SetiosCamera (obj1);
		GameManager.Instance.SetPCCamera (GameObject.FindGameObjectWithTag ("PCCamera"));
		GameManager.Instance.SetiosCamera(player.transform.Find("CardboardMainHack").gameObject);
		*/
		#endif
		#if UNITY_EDITOR
		//photonView.RPC("JoinPCPlayer",PhotonTargets.Others);
		#endif

	}
	void OnGUI(){
		//Photonのステータスをラベルで表示させています
	
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	
	}

	[PunRPC]
	void JoinPCPlayer(){
		#if UNITY_IOS
		GameManager.Instance.SetPCCamera (GameObject.FindGameObjectWithTag ("PCCamera"));
		GameManager.Instance.SetiosCamera(player.transform.Find("CardboardMainHack").gameObject);
		#endif
	}

	[PunRPC]
	void SendMes(){

	}

}
