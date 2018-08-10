namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;

    public class ControllableReactor : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";
		private bool maxReached = false;
		private bool minReached = false;
		public GameObject waterDrop;
		public Transform startPosition;
		private AudioSource audioSource;

        protected virtual void OnEnable()
        {
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
            controllable.ValueChanged += ValueChanged;
            controllable.MaxLimitReached += MaxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
        }

        protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            if (displayText != null)
            {
                displayText.text = e.value.ToString("F1");
            }
        }

        protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMax != "")
            {
                Debug.Log(outputOnMax);
				maxReached = true;
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMin != "")
            {
                Debug.Log(outputOnMin);
				if (maxReached == true) {
					minReached = true;
					Debug.Log ("Pump water");
				}
            }
        }

		// Use this for initialization
		void Start () {
			audioSource = GetComponent<AudioSource> ();
		}

		// Update is called once per frame
		void Update () {

			if (minReached == true && maxReached == true){
				if (!IsInvoking("pumpWater")){
					Invoke("pumpWater", 0f);
					minReached = false;
					maxReached = false;
				}
			}


		}		

		void pumpWater(){
			GameObject droplet = Instantiate (waterDrop) as GameObject;
			waterDrop.transform.position = startPosition.position;
			audioSource.PlayOneShot(SoundManager.Instance.waterDropClip);
		}


	}
}
