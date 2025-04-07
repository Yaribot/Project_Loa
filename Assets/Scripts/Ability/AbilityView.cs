using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Architecture.AbilitySystem
{
    public class AbilityView : MonoBehaviour
    {
        [SerializeField] public Abilitybutton[] buttons;

        //private readonly Key[] keys = {key}

        private void Awake()
        {
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Initialize(i);
            }
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Updateradial(float progress)
        {
            if (float.IsNaN(progress))
            {
                progress = 0f;
            }
            Array.ForEach(buttons, button => button.UpdateRadialFill(progress));
        }

        public void UpdateButtonSprites(IList<Ability> abilities)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if(i < abilities.Count)
                {
                    buttons[i].UpdateButtonSprite(abilities[i].data.icon);
                }
                else
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
