using UnityEngine;

public class health : MonoBehaviour
{
	[SerializeField] private float startingHealth;
	private float currentHealth;
	private Animator anim;
	private bool dead;


	private void Awake()
	{
		currentHealth = startingHealth;
		anim = GetComponent<Animator>();
	}
	public void TakeDamage(float _damage)
	{
		currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
		
		if (currentHealth > 0)
		{
			anim.SetTrigger("hurt");
		}
		else
		{
			if (!dead)
			{
				anim.SetTrigger("die");
				GetComponent<PlayerMovement>().enabled = false;
				dead = true;
			}
		}
	}
}
