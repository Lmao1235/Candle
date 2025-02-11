using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public float Health;
    public TextMeshProUGUI HP;
    private float _currentHealth;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private Transform _healthBarTransform;
    private float _damageAmount;
    private Camera _camera;
    public GameObject death;
    public GameObject Player;
    Vector2 checkpointPos;
    public int BTM;
    private Animator anim;

    public GameObject Dead;
    [SerializeField] Transform DeadPos;

    public GameObject RespawnCanva;

    private void Awake()
    {
        _currentHealth = Health;
        _camera = Camera.main;
    }

    public void Start()
    {
        checkpointPos = transform.position;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        _healthBarTransform.rotation = _camera.transform.rotation;
    }

    public void GotDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, Health);
        HP.text = "HP: " + _currentHealth.ToString(); ;
        if (_currentHealth <= 0)
        {
            _currentHealth = Health;
            anim.SetTrigger("Death");
            Death();
        }
        _healthBarFill.fillAmount = _currentHealth / Health;
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    public void Death()
    {

        gameObject.SetActive(false);
        RespawnCanva.SetActive(true);
        Instantiate(Dead, DeadPos.position, Quaternion.identity);
    }

    public void Respawn()
    {
        transform.position = checkpointPos;
        gameObject.SetActive(true);
        Health = 10;
        _currentHealth = Health;
        HP.text = "HP: " + Health.ToString();
        _healthBarFill.fillAmount = 1f;
        RespawnCanva.SetActive(false);
        anim.Play("Idle");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Heal")
        {
            Health = _currentHealth + 2;
            
            Destroy(other.gameObject);
            Debug.Log(Health);
            if (Health > 10)
            {
                Health = 10;
            }
            _currentHealth = Health;
            HP.text = "HP: " + Health.ToString();
            GotDamage(_damageAmount);
            _healthBarFill.fillAmount = _currentHealth * Health;
        }
    }

    

    public void BackToMenu()
    {
        RespawnCanva.SetActive(false);
        SceneManager.LoadScene(BTM, LoadSceneMode.Single);
    }

    
}