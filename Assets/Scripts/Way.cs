using UnityEngine;
using System.Collections;

public class Way : MonoBehaviour {
    public GameObject[] mObjects;
	// Use this for initialization
	void Start () {
        //在每段路段上随机产生20到50个物品
        int mCount = Random.Range(20, 50);
        for (int i = 0; i < mCount; i++)
        {
            Instantiate(mObjects[0], new Vector3(Random.Range(this.transform.position.x - 30, this.transform.position.x + 30), 0.6F, 0F),
                          Quaternion.Euler(new Vector3(90F, 180F, 0F)));
        }
        //在每段路段上随机产生5到10个障碍物
        mCount = Random.Range(5, 10);
        for (int i = 0; i < mCount; i++)
        {
            Instantiate(mObjects[1], new Vector3(Random.Range(this.transform.position.x - 25, this.transform.position.x + 25), 0.5F, 0F),
                          Quaternion.Euler(new Vector3(90F, 180F, 0F)));
        }
	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
