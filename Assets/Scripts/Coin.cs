using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	//这里是一个控制金币旋转的脚本

	void Update () 
	{
		transform.Rotate(Vector3.forward * 50F * Time.deltaTime);
	}

	//当离开摄像机视野时立即销毁
	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
