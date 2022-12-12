using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DogVsCat
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager I;

		public GameObject Dog;
		public GameObject Food;
		public GameObject NomalCat;
		public GameObject RetryBtn;

		void Awake()
        {
			I = this;
        }

        // Start is called before the first frame update
        void Start()
	    {
			InvokeRepeating("MakeFood", 0.0f, 0.2f);
			InvokeRepeating("MakeCat", 0.0f, 1.0f);
		}

	    // Update is called once per frame
	    void Update()
	    {
	        
	    }

		void MakeFood()
        {
			float x = Dog.transform.position.x;
			float y = Dog.transform.position.y + 2.0f;
			Instantiate(Food, new Vector3(x, y, 0), Quaternion.identity);
		}

		void MakeCat()
		{	
			Instantiate(NomalCat);
		}

		public void GameOver()
        {
			RetryBtn.SetActive(true);
			Time.timeScale = 0f;
        }
	}
}