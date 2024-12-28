using LifeTodo.Domain;
using LifeTodo.UseCase;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LifeTodo.UI
{
    public class TodoCellView : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [SerializeField]
        private TMP_Text title;

        [SerializeField]
        private TMP_Text status;

        [Inject]
        private TodoExpireDomainService expireService;

        [Inject]
        private TodoAppService appService;

        private TodoDto todo;
        private int index;

        public void SetTodo(int indexList, TodoDto todoDto)
        {
            this.todo = todoDto;
            this.index = indexList;

            UpdateTodoView();

            button.onClick.AddListener(OnDone);
        }

        private void UpdateTodoView()
        {
            TimeSpan remainTime = expireService.CalcRemainTime(todo.CreatedDate);
            string statusText = todo.Status == TodoStatus.Active
                ? $"残り{remainTime:dd}日"
                : todo.Status.ToString();

            Debug.Log($"{index}:\t{todo.Text}\t{statusText}");
            title.text = $" {index}:\t{todo.Text}";
            status.text = statusText;
            button.gameObject.SetActive(todo.Status == TodoStatus.Active);
        }

        private void OnDone()
        {
            appService.DoTodo(todo);
        }
    }
}