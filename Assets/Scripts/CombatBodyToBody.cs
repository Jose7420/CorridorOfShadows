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
    [SerializeField]private AudioClip _audioBat;
    [SerializeField]private AudioClip _audioBoss;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
    }
    /*
    // Update is called once per frame
    void Update()
    {
        //if (_TimeNextAttack > 0)
        //{
        //    _TimeNextAttack -= Time.deltaTime;
        //}
        //if (Input.GetKeyDown("b") && _TimeNextAttack <=  0)
        //{
        //    Golpe();
        //    _TimeNextAttack = _timeBetweenAttack;
        //}
    }*/

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
       

        Collider2D[] objects = Physics2D.OverlapCircleAll(_hitController.position, _hitRadius);
        StartCoroutine(MethodName);
        StartCoroutine(LateHit(objects));






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

    private IEnumerator LateHit(Collider2D[] objects)
    {
        yield return new WaitForSeconds(0.40f);
        CheckWhoHitsWho(objects);

    }


    private void CheckWhoHitsWho(Collider2D[] objects )
    {
        foreach (Collider2D collisionador in objects)
        {

            if (collisionador.CompareTag("Jefe"))
            {
                AcitveSound(_audioBoss);
                collisionador.GetComponent<Jefe>().TakeDamage(_hitDamage);
                // Debug.Log(collisionador.name);
               

            }
            if (collisionador.CompareTag("Enemy"))
            {
                AcitveSound(_audioBat);
                GameManagerLocal.Instance.AddPoints(5);
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
