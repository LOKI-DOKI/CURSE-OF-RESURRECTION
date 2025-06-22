using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damageAmount = 50;
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {
            transform.parent = other.transform;
 
            other.GetComponent<Enemy1>().TakeDamage(damageAmount);
        }


    }
}
