using UnityEngine;
using System.Collections;

public class CubeWay : MonoBehaviour {

	//在道路上显示的金币、障碍物
	public GameObject[] mObjects;


	void Start () 
	{

	   //在每段路段上随机产生20到50个物品
	   int mCount=Random.Range(20,50);
	   for(int i=0;i<mCount;i++)
	   {
		  Instantiate(mObjects[0],new Vector3(Random.Range(this.transform.position.x-25,this.transform.position.x+25),1F,-2F),
			            Quaternion.Euler(new Vector3(90F,180F,0F)));
	   }
	   //在每段路段上随机产生5到10个障碍物
	   mCount=Random.Range(5,10);
	   for(int i=0;i<mCount;i++)
	   {
		  Instantiate(mObjects[1],new Vector3(Random.Range(this.transform.position.x-25,this.transform.position.x+25),0.5F,-2F),
				        Quaternion.Euler(new Vector3(90F,180F,0F)));
	   }
	}

	//当离开摄像机视野时立即销毁
	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

}
