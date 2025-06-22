using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    public int HP = 100;
    public Slider healthbar;

    public Animator animator;

    public AudioSource audio;
    public AudioClip death;
    public AudioClip damage;
    private void Start()
    {
        //audioManager = AudioManager.instance; // Get AudioManager instance
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            //if (audioManager != null)
            {
              //  audioManager.Play("roar");
            }
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            audio.PlayOneShot(death);
        }
        else
        {
            animator.SetTrigger("damage");
            audio.PlayOneShot(damage);  
        }
    }
    public void Update()
    {
        healthbar.value = HP;
    }
}
