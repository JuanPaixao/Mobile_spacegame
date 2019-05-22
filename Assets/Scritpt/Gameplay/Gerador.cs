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
    private Rect _area; //rect for retangle
    [SerializeField] private Transform _target;
    [SerializeField] private int _score;
    [SerializeField] private EnemiesBackup _enemiesBackup;

    private void Start()
    {
        InvokeRepeating("Instanciar", 0, this.tempo);
    }

    private void Instanciar()
    {
        if (this._enemiesBackup.HasEnemy())
        {
            GameObject inimigo = this._enemiesBackup.ActiveEnemy();
            this.DefinirPosicaoInimigo(inimigo);
            inimigo.GetComponent<FollowPlayer>().SetTarget(this._target);
            inimigo.GetComponent<Scoreable>().SetScore(this._score);
        }
    }

    private void DefinirPosicaoInimigo(GameObject inimigo)
    {
        var posicaoAleatoria = new Vector2
        (Random.Range(this._area.x, this._area.x + this._area.width), // the spawn pos will cycle between my X and my total between X + any value until my total width, same for Y
        Random.Range(this._area.y, this._area.y + this._area.y + this._area.height));
        Vector2 posicaoInimigo = (Vector2)this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(100, 0, 100);
        Vector2 position = this._area.position + (Vector2)this.transform.position + this._area.size / 2;
        Gizmos.DrawWireCube(position, this._area.size);
    }
}
