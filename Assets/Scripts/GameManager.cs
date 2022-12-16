using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DogVsCat
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager I;

		public GameObject Dog;
		public GameObject Food;
		public GameObject NomalCat;
		public GameObject FatCat;

		public GameObject RetryBtn;
		public Text levelText;
		public GameObject levelBarFront;

		int level = 0;
		int cat = 0;

		void Awake()
        {
			I = this;
        }

        // Start is called before the first frame update
        void Start()
	    {
			Time.timeScale = 1f;
			InvokeRepeating("MakeFood", 0.0f, 0.05f);
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

			if (level == 1)
            {
				float p = Random.Range(0, 10);
				if(p < 2)
					Instantiate(NomalCat);
			}
			else if (level == 2)
            {
				float p = Random.Range(0, 10);
				if (p < 5)
					Instantiate(NomalCat);
			}
			else if (level >= 3)
			{
				float p = Random.Range(0, 10);
				if (p < 6)
					Instantiate(FatCat);
			}
		}

		public void GameOver()
        {
			RetryBtn.SetActive(true);
			Time.timeScale = 0f;
        }

		public void addCat()
        {
			cat += 1;
			level = cat / 5;
			// Debug.Log($"cat = {cat}, level = {level}");

			levelText.text = level.ToString();
			levelBarFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f);

		}
	}
}