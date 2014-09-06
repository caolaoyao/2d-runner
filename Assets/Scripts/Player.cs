using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//定义角色移动速度
	public float mMoveSpeed=2.5F;

	//摄像机
	private Transform mCamera;
	//背景图片
	private Transform mBackground;

	//角色是否在奔跑
	private bool isRuning=true;
	//场景中路段总数目
	private int mCount=1;

	//路段预设
	public GameObject CubeWay;

	//死亡动画播放次数
	private int DeathCount=0;
	//收集的金币数目
	private int mCoinCount=0;
	public int CoinCount {
		get {
			return mCoinCount;
		}
	}

	//当前奔跑距离
	private int mLength=0;
	public int Length {
		get {
			return mLength;
		}
	}

	//当前得分
	private int mGrade=0;
	public int Grade {
		get {
			return mGrade;
		}
	}

	void Start () 
	{
	    //获取相机
		mCamera=Camera.main.transform;
		//获取背景
		mBackground=GameObject.Find("Background").transform;
	}

	void Update () 
	{
		//如果角色处于奔跑状态则移动角色、相机和场景
		if(isRuning)
		{
			Move();
			CreateCubeWay();
			Jump();
			UpdateData();
		}else
		{
			Death();
		}
	}

	/// <summary>
	/// 更新玩家的游戏数据
	/// </summary>
	private void UpdateData()
	{
		//计算奔跑距离
		mLength=(int)((transform.position.x+25)*25);
		//计算玩家得分
		mGrade=(int)(mLength*0.8+mCoinCount*0.2);
	}


	///角色死亡
	private void Death()
	{
		//为避免死亡动画在每一帧都更新，使用DeathCount限制其执行
		if(DeathCount<=1)
		{
		   //播放死亡动画
		   transform.animation.Play("Lose");
		   //次数+1
		   DeathCount+=1;
		   //保存当前记录
		   //PlayerPrefs.SetInt("这里填入一个唯一的值",Grade);
		}
	}

	private void Jump()
	{
		//这里不能使用刚体结构，所以使用手动方法实现跳跃
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
		{
			while(transform.position.y<=1)
			{
				float y=transform.position.y+0.02F;
				transform.position=new Vector3(transform.position.x,y,transform.position.z);
				transform.animation.Play("Jump");
			}
			StartCoroutine("Wait");
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.8F);
		//角色落地继续奔跑
		while(transform.position.y>0.125F)
		{
			float y=transform.position.y-0.02F;
			transform.position=new Vector3(transform.position.x,y,transform.position.z);
			transform.animation.Play("Run");
		}
	}

	//移动角色、相机和场景
	private void Move()
	{
		//让角色从左到右开始奔跑
		transform.Translate(Vector3.forward * mMoveSpeed * Time.deltaTime);
		//移动摄像机
		mCamera.Translate(Vector3.right * mMoveSpeed * Time.deltaTime);
		//移动背景
		mBackground.Translate(Vector3.left * mMoveSpeed * Time.deltaTime);
	}

	//创建新的路段
	private void CreateCubeWay()
	{
		//当角色跑完一个路段的的2/3时，创建新的路段
		//用角色跑过的总距离计算前面n-1个路段的距离即为在第n个路段上跑过的距离
		if(transform.position.x+30-(mCount-1)*50 >=50*2/3)
		{
			//克隆路段
			//这里从第一个路段的位置开始计算新路段的距离
			GameObject mObject=(GameObject)Instantiate(CubeWay,new Vector3(-5F+mCount * 50F,0F,-2F),Quaternion.identity);
			mObject.transform.localScale=new Vector3(50F,0.25F,1F);
			//路段数加1
			mCount+=1;
		}
	}

	void OnTriggerEnter(Collider mCollider)
	{
		//如果碰到的是金币，则金币消失，金币数目加1;
		if(mCollider.gameObject.tag=="Coin")
		{
			Destroy(mCollider.gameObject);
			mCoinCount+=1;
		}
		//如果碰到的是障碍物，则游戏结束
		else if(mCollider.gameObject.tag=="Rock")
		{
			isRuning=false;
		}
	}
}
