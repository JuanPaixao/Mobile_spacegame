using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBackup : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _quantity;
    private Stack<GameObject> _enemiesStack; //Stack because i can always call the enemie on top of it
    public bool withEnemies;
    private void Start()
    {
        this._enemiesStack = new Stack<GameObject>();
        this.CreateAllEnemies();
    }
    private void CreateAllEnemies()
    {
        for (int i = 0; i < this._quantity; i++)
        {
            GameObject enemy = GameObject.Instantiate(this._enemy, this.transform);//instantiate it on this transform as a child
            EnemyBackupObject backupEnemy = enemy.GetComponent<EnemyBackupObject>();
            backupEnemy.SetBackup(this);
            enemy.SetActive(false);
            this._enemiesStack.Push(enemy); // added my enemy on my stack
        }
    }
    public GameObject ActiveEnemy()
    {
        GameObject enemy = this._enemiesStack.Pop();
        enemy.SetActive(true);
        return enemy; //pick the first object on my stack and return it
        Debug.Log("test");
    }
    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        this._enemiesStack.Push(enemy);

    }
    public bool HasEnemy()
    {
        
        return this._enemiesStack.Count > 0;
    }
}
