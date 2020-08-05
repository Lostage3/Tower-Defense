using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyPool Pool { get; set; } 
    public Monster monster;

    void Start()
    {
        monster = new Monster(5);
        MonsterData monDat = monster.MonsterData;
        monster.MonsterData = monDat;
        monster.TestNum = 5;
        monster = new Monster(6, gameObject);
        Debug.Log(monster.AnotherTestNum + " " + monster.go);
    }

   // void OnCollisionEnter(Collision collision)
   // {
   //     if(!collision.gameObject.CompareTag("Enemy"))
   //   {
   //       Pool.ReturnToPool(this);
   //   }
   // }
}

[System.Serializable]
public class Monster
{
    public GameObject go;

    public Monster(int myNum)
    {
        AnotherTestNum = myNum;
    }

    public Monster(int myNum, GameObject go)
    {
        AnotherTestNum = myNum;
        this.go = go;
    }

    public Monster()
    {
    }

    public MonsterData MonsterData
    {
        get { return monsterData; }
        set { monsterData = value; }
    }
    MonsterData monsterData;

    public int TestNum
    {
        get { return testNum; }
        set { testNum = value; }
    }
    int testNum;

    public int AnotherTestNum { get; }

    public float Bla { get; set; } = 12f;
    public float Bla2 { get; set; } = 40f;

    [SerializeField] int yetAnotherTestNum = 1;
    public int YetAnotherTestNum
    {
        get => yetAnotherTestNum;
        set => yetAnotherTestNum = value;
    }


    public void DecreaseHealth(int amount)
    {
        monsterData.Health -= amount;
    }

    //public MonsterData GetMonsterData()
    //{
    //    return monsterData;
    //}

    //public void SetMonsterData(MonsterData md)
    //{
    //    monsterData = md;
    //}
}

public struct MonsterData
{
    public int Health;
    public bool IsScary;
    public Vector3 Dir;
}

