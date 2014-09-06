using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	//当离开摄像机视野时立即销毁
	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
