using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBackupObject : MonoBehaviour
{
    private EnemiesBackup _myBackup;

    public void SetBackup(EnemiesBackup backup)
    {
        this._myBackup = backup;
    }
    public void ReturnToBackup()
    {
        this._myBackup.ReturnEnemy(this.gameObject);
    }
}
