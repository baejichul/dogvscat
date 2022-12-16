using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogVsCat
{
	public class Cat : MonoBehaviour
	{
		float full   = 5.0f;
		float energy = 0.0f;
		bool isFull = false;
		public int type;

		// Start is called before the first frame update
		void Start()
	    {
			float x = Random.Range(-8.5f, 8.5f);
			float y = 30.0f;


			if (type == 1)
            {
				full = 10f;
            }
			transform.position = new Vector3(x, y, 0);
		}

	    // Update is called once per frame
	    void Update()
	    {
			if ( energy < full)
            {

				if (type == 0)
				{
					transform.position += new Vector3(0, -0.005f, 0);
				}
				else if (type == 1)
                {
					transform.position += new Vector3(0, -0.01f, 0);
				}

					

				if ( transform.position.y < -16.0f)
                {
					GameManager.I.GameOver();
                }
			}
            else
            {
				if (transform.position.x > 0)
                {
					transform.position += new Vector3(0.05f, 0, 0);
				}
                else
                {
					transform.position += new Vector3(-0.05f, 0, 0);
				}
				Destroy(gameObject, 3.0f);
            }
		}

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Food")
            {
				// Debug.Log($"collison = {collision.gameObject.tag}");
				if (energy < full)
                {
					energy += 1.0f;
					Destroy(collision.gameObject);

					Vector3 vecScale = new Vector3(energy/full, 1, 1);
					transform.Find("Hungry/HpBar/Front").localScale = vecScale;
				}
                else
                {
					if (isFull == false)
                    {
						GameManager.I.addCat();
						transform.Find("Hungry").gameObject.SetActive(false);
						transform.Find("Full").gameObject.SetActive(true);
						isFull = true;
					}
				}
			}
        }
    }
}