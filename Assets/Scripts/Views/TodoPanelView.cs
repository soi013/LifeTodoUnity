using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using LifeTodo.Domain;
using LifeTodo.UseCase;

namespace LifeTodo.Views
{
    public class TodoPanelView : MonoBehaviour
    {
        [SerializeField]
        private GameObject todoPrefab;

        [SerializeField]
        private GameObject todoCellsRoot;

        [Inject]
        private   TodoAppService appService;
        
        [Inject]
        private TodoExpireDomainService expireService;

        private static IReadOnlyList<TodoDto> currentActiveTodos =Array.Empty<TodoDto>();
        private static IReadOnlyList<TodoDto> currentInactiveTodos = Array.Empty<TodoDto>();

        private void Start()
        {
        }

        private void UpdateAndShowTodos(IReadOnlyList<TodoDto> activeTodos, IReadOnlyList<TodoDto> inactiveTodo)
        {
            if (currentActiveTodos.SequenceEqual(activeTodos)&& currentInactiveTodos.SequenceEqual(inactiveTodo))
            {
                return;
            }
            
            currentActiveTodos = activeTodos.ToList();
            currentInactiveTodos = inactiveTodo.ToList();

            ClearTodoViews();
            
            foreach (var (todo, index) in currentActiveTodos.Select((t, i) => (t, i)))
            {
                CreateTodoUi(index,todo);
            }
            
            foreach (var (todo, index) in currentInactiveTodos.Select((t, i) => (t, i)))
            {
                CreateTodoUi(index,todo);
            }
        }

        private void CreateTodoUi(int index, TodoDto todoDto)
        {
            GameObject todoGo =   Instantiate(todoPrefab, transform.position, Quaternion.identity, transform);
            TodoCellView todoView = todoGo.GetComponent<TodoCellView>();
   
            todoView.SetTodo(index, todoDto);
        }

        private void ClearTodoViews()
        {
            IEnumerable<TodoCellView> cells = todoCellsRoot.GetComponentsInChildren<TodoCellView>();
            foreach (TodoCellView cell in cells)
            {
                cell.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            UpdateAndShowTodos(appService.GetActiveTodos(), appService.GetInactiveTodos());
        }
    }
}