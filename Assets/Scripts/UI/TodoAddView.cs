using LifeTodo.UseCase;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LifeTodo.UI
{
    public class TodoAddView : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [SerializeField]
        private TMP_Text title;

        [Inject]
        private TodoAppService appService;

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