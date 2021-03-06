﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	//Instanciando esta classe
	[HideInInspector]
	public static Player PlayerInstance;
	[HideInInspector]
	public PlayerAttributes Play_Att;

	[Header("Shoot Buttoms")]
	public KeyCode MainButtom, RightButtom, LeftButtom;

	//Listas que armazenam os sprites dos canhoes.
	[Header("Cannon Sprites")]
	public List<Sprite> MainCannonSprites, RightCannonSprites, LeftCannonSprites;

	//Posiçoes de onde as balas de cada canhao sairao
	private Transform MainShootPosition, RightShootPosition, LeftShootPosition;

	void Start () 
	{
		PlayerInstance = this;
		Play_Att = GameObject.Find ("GameAdmin").GetComponent<PlayerAttributes> ();

		//Atribuindo as posiçoes de tiro
		MainShootPosition = gameObject.transform.FindChild ("MainCannon").transform.FindChild ("ShootPosition").transform;
		RightShootPosition = gameObject.transform.FindChild ("RightCannon").transform.FindChild ("ShootPosition").transform;
		LeftShootPosition = gameObject.transform.FindChild ("LeftCannon").transform.FindChild ("ShootPosition").transform;
	}

	void Update () 
	{
		Inputs ();
	}

	void Inputs()
	{
		//Se eu aperto o botao de tiro do canhao do meio + Delay do canhao do meio esta menor que 0 + Este objeto esta vivo.
		if(Input.GetKey(MainButtom) && Play_Att.MainCanShoot == true)
		{
			GameObject MainBullet = Instantiate(Play_Att.Bullet, MainShootPosition.transform.position, Quaternion.identity) as GameObject;
			MainBullet.transform.SetParent (this.gameObject.transform.FindChild("MainCannon").transform);
			Play_Att.MainDelay = Play_Att.MainStartDelay;
		}
		
		if(Input.GetKey(RightButtom) && Play_Att.RightCanShoot == true)
		{
			GameObject RightBullet = Instantiate(Play_Att.Bullet, RightShootPosition.transform.position, Quaternion.identity) as GameObject;
			RightBullet.transform.SetParent(this.gameObject.transform.FindChild("RightCannon").transform);
			RightBullet.transform.localEulerAngles = new Vector3(0,0,45);
			Play_Att.RightDelay = Play_Att.RightStartDelay;
		}
		
		if(Input.GetKey(LeftButtom) && Play_Att.LeftCanShoot == true)
		{
			GameObject LeftBullet = Instantiate(Play_Att.Bullet, LeftShootPosition.transform.position, Quaternion.identity) as GameObject;
			LeftBullet.transform.SetParent(this.gameObject.transform.FindChild("LeftCannon").transform);
			LeftBullet.transform.localEulerAngles = new Vector3(0,0,315);
			Play_Att.LeftDelay = Play_Att.LeftStartDelay;
		}
	}
}