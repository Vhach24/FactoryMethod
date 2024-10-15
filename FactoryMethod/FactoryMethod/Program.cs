namespace FactoryMethod
{
    // Інтерфейс для кнопок
    public interface IButton
    {
        void Render(); // Метод для рендерингу кнопки
        void OnClick(Action action); // Метод для обробки події кліку
    }

    // Абстрактний клас для діалогів
    public abstract class Dialog
    {
        // Фабричний метод, який підклас повинен реалізувати
        protected abstract IButton CreateButton();

     
        public void Render()
        {
            IButton okButton = CreateButton(); // Виклик фабричного методу
            okButton.OnClick(CloseDialog); // Прив’язка дії до кнопки
            okButton.Render(); // Рендеринг кнопки
        }

        // Метод для закриття діалогу
        private void CloseDialog()
        {
            Console.WriteLine("Dialog closed."); // Діалог закрито.
        }
    }

    // Реалізація діалогу для Windows
    public class WindowsDialog : Dialog
    {
      
        protected override IButton CreateButton()
        {
            return new WindowsButton(); // Повертаємо Windows кнопку
        }
    }

    // Реалізація діалогу для Web
    public class WebDialog : Dialog
    {
        // Реалізація фабричного методу
        protected override IButton CreateButton()
        {
            return new HTMLButton(); // Повертаємо HTML кнопку
        }
    }

    // Реалізація кнопки для Windows
    public class WindowsButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Windows button."); // Рендеринг кнопки в стилі Windows
        }

        public void OnClick(Action action)
        {
            Console.WriteLine("Windows button clicked."); // Обробка кліку на кнопці
            action.Invoke(); // Виклик переданої дії
        }
    }

    // Реалізація кнопки для Web
    public class HTMLButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering HTML button."); // Рендеринг HTML кнопки
        }

        public void OnClick(Action action)
        {
            Console.WriteLine("HTML button clicked."); // Обробка кліку на кнопці
            action.Invoke(); // Виклик переданої дії
        }
    }

    // Головний клас програми
    internal class Program
    {
        private static void Main(string[] args)
        {
            Dialog dialog;

            // Вибір діалогу на основі конфігурації (можна змінити на "Web" для перевірки)
            string os = "Windows"; // Наприклад, система Windows
            if (os == "Windows")
            {
                dialog = new WindowsDialog(); // Створюємо Windows діалог
            }
            else if (os == "Web")
            {
                dialog = new WebDialog(); // Створюємо Web діалог
            }
            else
            {
                throw new Exception("Unknown operating system."); // Помилка, якщо система невідома
            }

            dialog.Render(); // Відображаємо діалог
        }
    }
}
