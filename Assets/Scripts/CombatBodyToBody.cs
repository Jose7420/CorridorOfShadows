using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CombatBodyToBody : MonoBehaviour
{
    [SerializeField] private Transform _hitController;
    [SerializeField] private float _hitRadius;
    [SerializeField] private float _hitDamage;
    [SerializeField] private float _timeBetweenAttack;
    [SerializeField] private float _TimeNextAttack;
    [SerializeField] private bool _isActiveHit;

    private Animator _animator;
    private const string MethodName = nameof(HitACtive);
    public bool IsActiveHit { get => _isActiveHit; }

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioBat;
    [SerializeField] private AudioClip _audioBoss;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

    }
  

    public void TimeBetweenAttack()
    {
        // Debug.Log($"Tiempo entre ataque es {tiempoEntreAtaque}");
        if (_TimeNextAttack > 0)
        {
            _TimeNextAttack -= Time.deltaTime;
        }

    }
    public void Stroke()
    {
        if (_TimeNextAttack <= 0)
        {
            Hit();
            _TimeNextAttack = _timeBetweenAttack;
        }

    }

    private void Hit()
    {
        _animator.SetTrigger("Hit");
        StartCoroutine(MethodName);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_hitController.position, _hitRadius);
    }


    private IEnumerator HitACtive()
    {
        _isActiveHit = true;
        yield return new WaitForSeconds(1);
        _isActiveHit = false;
    }


    // funcion que es llamada por la animacion de golpear.
    private void CheckWhoHitsWho()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(_hitController.position, _hitRadius);

        Debug.Log("dentro del checkWhoHitsWho");
        foreach (Collider2D collisionador in objects)
        {
            if (collisionador == null) continue;
            if (collisionador.CompareTag("Jefe"))
            {
                AcitveSound(_audioBoss);
                collisionador.GetComponent<Jefe>().TakeDamage(_hitDamage);
                Debug.Log(collisionador.name);


            }
            if (collisionador.CompareTag("Enemy"))
            {
                AcitveSound(_audioBat);
                GameManagerLocal.Instance.AddPoints(5);
                Debug.Log(collisionador.name);

                Destroy(collisionador.gameObject);

            }

        }
    }

    #region Reproducir sonidos
    /// <summary>
    /// Se reproduce el sonido que se le pasa por el parametro.
    /// </summary>
    /// <param name="audioClip"> El sonido se pasa por paramtros</param>
    public void AcitveSound(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
    #endregion


}
