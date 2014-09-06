using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//游戏界面根节点
	private Transform GameUI;
	//玩家
	private Transform mPlayer;
	//界面金币数及距离
	private Transform mCoins;
	private Transform mLength;

	void Start () 
	{
		GameUI=GameObject.Find("2DUI").transform;
		mPlayer=GameObject.Find("People").transform;
		mCoins=GameUI.FindChild("Anchor/Panel/Coins").transform;
		mLength=GameUI.FindChild("Anchor/Panel/Length").transform;
	}

	void Update () 
	{
		mCoins.GetComponent<UILabel>().text="金币:" + mPlayer.GetComponent<Player>().CoinCount;
		mLength.GetComponent<UILabel>().text="距离:" + mPlayer.GetComponent<Player>().Length;
	}
}
