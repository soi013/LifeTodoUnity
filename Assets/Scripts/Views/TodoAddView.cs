using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using LifeTodo.Domain;
using LifeTodo.UseCase;
using TMPro;
using UnityEngine.UI;

namespace LifeTodo.Views
{
    public class TodoAddView : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [SerializeField]
        private TMP_Text title;

        [Inject]
        private   TodoAppService appService;
        

        private void Start()
        {
            button.onClick.AddListener(OnAdd);
        }

        private void OnAdd()
        {
            appService.AddTodo(title.text);
            title.text = string.Empty;
        }
    }
}