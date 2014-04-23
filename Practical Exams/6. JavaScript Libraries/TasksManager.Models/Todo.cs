namespace TasksManager.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsDone { get; set; }

        public int ListId { get; set; }

        public virtual TodoList List { get; set; }
    }
}