using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int health = 100;
    Animator anim;
	public float invulnPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;
    bool ptje;
    public AudioClip shootSound;
    private AudioSource source;

    SpriteRenderer spriteRend;

	void Start() {
        ptje = false;
		correctLayer = gameObject.layer;
        source = GetComponent<AudioSource>();
        // NOTE!  This only get the renderer on the parent object.
        // In other words, it doesn't work for children. I.E. "enemy01"
        spriteRend = GetComponent<SpriteRenderer>();

		if(spriteRend == null) {
			spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

			if(spriteRend==null) {
				Debug.LogError("Object '"+gameObject.name+"' has no sprite renderer.");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
        if (gameObject.tag != col.tag && col.tag !="untagged")
        {
            health = health - 10;

            if (invulnPeriod > 0)
            {
                invulnTimer = invulnPeriod;
                gameObject.layer = 10;
                source.Play();
            }
        }
	}

	void Update() {

		if(invulnTimer > 0) {
			invulnTimer -= Time.deltaTime;

			if(invulnTimer <= 0) {
				gameObject.layer = correctLayer;
				if(spriteRend != null) {
					spriteRend.enabled = true;
				}
			}
			else {
				if(spriteRend != null) {
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}

		if(health <= 0) {
            ptje = false; ;

            Die();
		}
	}

	void Die() {
        Destroy(gameObject);
        if (gameObject.tag.Equals("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
