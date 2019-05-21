using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{
    // [SerializeField]
    // private GameObject prefabInimigo;
    [SerializeField]
    private float tempo;
    [SerializeField]
    private float raio;
    [SerializeField] private Transform _target;
    [SerializeField] private int _score;
    [SerializeField] private EnemiesBackup _enemiesBackup;

    private void Start()
    {
        InvokeRepeating("Instanciar", 0, tempo);
    }

    private void Instanciar()
    {
        if (_enemiesBackup.HasEnemy())
        {
            GameObject inimigo = this._enemiesBackup.ActiveEnemy();
            inimigo.SetActive(true);
            this.DefinirPosicaoInimigo(inimigo);
            inimigo.GetComponent<FollowPlayer>().SetTarget(this._target);
            inimigo.GetComponent<Scoreable>().SetScore(this._score);
        }
    }

    private void DefinirPosicaoInimigo(GameObject inimigo)
    {
        var posicaoAleatoria = new Vector3(
                        Random.Range(-this.raio, this.raio),
                        Random.Range(-this.raio, this.raio),
                        0);

        var posicaoInimigo = this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }
}
