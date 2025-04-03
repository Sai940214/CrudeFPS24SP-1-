using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    // Start is called before the first frame update

        [SerializeField] Light lightBulb;

        private void Start()
        {
            lightBulb.enabled = false;
        }

        public void ToggleFlashlight()
        {
            lightBulb.enabled = !lightBulb.enabled;
        }
}
