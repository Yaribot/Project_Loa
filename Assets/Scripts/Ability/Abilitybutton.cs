using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Architecture.AbilitySystem
{
    public class Abilitybutton : MonoBehaviour
    {
        public Image radialImage;
        public Image abilityIcon;
        public int index;
        public Key key;
        [SerializeField] InputReader input;

        public event Action<int> OnButtonPressed = delegate { };

        public void Initialize(int index, Key key)
        {
            this.index = index;
            this.key = key;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => OnButtonPressed(index));
        }

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current[key].wasPressedThisFrame)
            {
                OnButtonPressed(index);
            }
        }

        public void RegisterListener(Action<int> listener)
        {
            OnButtonPressed += listener;
        }

        public void updatebuttonSprite(Sprite newIcon)
        {
            abilityIcon.sprite = newIcon;
        }

        public void UpdateRadialFill(float progress)
        {
            if (radialImage)
            {
                radialImage.fillAmount = progress;
            }
        }
    }
}
