using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PeopleAccounting.UI
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void open_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Програма відкриває текстові файли *.txt і переносить їх у таблицю, зручну для читання: пункт головного меню Файл->Відкрити… або кнопка панелі інструментів. Файл повинен бути заповнений рядками, розділеними символом переносу рядка (кожний запис з нового рядка), дані про людину мають бути організовані у форматі:\n\n\n");
            Bold form = new Bold();
            form.Inlines.Add("{ІД}|{Прізвище}|{Ім’я}|{Телефону(«+380…»)}|{Країна}|{Область}|{Місто/село/смт}|{Вулиця}|{Номер будинку}|{Номер квартири}\n\n\n");
            Run content1 = new Run("Опрацьовуються лише ті рядки файлу, для яких розрахований функціонал ПЗ. (Рис. 1).Якщо в файлі деякі рядки не можуть бути інтерпретовані як інформація про людину, то вони будуть занесені до журналу некоректних записів, вміст якого відобразиться одразу після завершення заповнення таблиці(Рис.2).");

            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
            this.paragraph.Inlines.Add(form);
            this.paragraph.Inlines.Add(content1);
        }

        private void save_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Для збереження таблиці у текстовий файл потрібно перейти до пункту головного меню Файл->Зберегти, або, якщо потрібно створити новий документ, Файл->Зберегти як…  або за допомогою відповідних кнопок на панелі інструментів.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void create_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб створити новий файл, треба перейти до пункту головного меню Файл->Новий або скористатись кнопкою на панелі інструментів.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void sort_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Сортувати список можна за ІД, прізвищем або іменем. Для цього необхідно натиснути на заголовок відповідної колонки в таблиці з записами.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void add_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб додати новий запис в таблицю, заповніть коректно форму редактора інформації на оберіть пункт головного меню Редагування->Додати до списку, або відповідну кнопку панелі інструментів.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void edit_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Редагування запису в таблиці можна здійснити, натиснувши на кнопці панелі інструментів: $, попередньо коректно заповнивши форму редактора інформації (Рис.3).");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void delete_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб видалити запис, треба виділити його в таблиці, натиснувши на нього і обрати пункт головного меню Редагування->Видалити запис, або натиснути кнопку на панелі інструментів.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void clear_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб очистити весь список, оберіть пункт головного меню Редагування->Очистити список або відповідну кнопку на панелі інструментів.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void toolBar_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб приховати панель інструментів, перейдіть у пункт головного меню Вигляд->Панель інструментів та зніміть галочку.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void choose_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб приховати панель з формою редактора інформації та категоріями пошуку, перейдіть у пункт головного меню Вигляд->Панель вибору та зніміть галочку.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void addressesByLastname_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб знайти адреси людей за прізвищем, введіть його в форму критеріїв пошуку (рис. 4) та натисніть на кнопку напроти тексту «Адреси за прізвищем:». Результати будуть відображені в новій вкладці поряд з вкладкою з основним списком.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void namesAddressesByNumber_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб знайти імена та адреси людей за номером, введіть його в форму критеріїв пошуку (рис. 4) та натисніть на кнопку напроти тексту «Імена і  адреси за номером:». Результати будуть відображені в новій вкладці поряд з вкладкою з основним списком.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void fullnameByAddress_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб знайти імена та прізвища людей за адресою, введіть її в форму критеріїв пошуку (рис. 4) та натисніть на кнопку напроти тексту «Повне ім’я за адресою:». Результати будуть відображені в новій вкладці поряд з вкладкою з основним списком.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void namesStreetsByNumber_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб знайти однакові імена та вулиці людей за однаковим номером, введіть його в форму критеріїв пошуку (рис. 4) та натисніть на кнопку напроти тексту «Імена/вулиці(однакові) за номером:». Результати будуть відображені в новій вкладці поряд з вкладкою з основним списком.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void peopleByLastname_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Щоб знайти повну інформацію про людей за прізвищем, введіть його в форму критеріїв пошуку (рис. 4) та натисніть на кнопку напроти тексту «Люди за прізвищем:». Результати будуть відображені в новій вкладці поряд з вкладкою з основним списком.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void error1_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Перевірте коректність введеного номера телефону: він повинен починатись з коду України «+380» та містити загалом 13 цифр разом з знаком плюс.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void error2_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Необхідно перевірити чи всі поля адреси чи редактора інформації заповнені.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void error3_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Перевірте, чи в поля номерів будинку, квартири чи ІД записані натуральні числа.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void error4_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Під час вибору адреси як критерію пошуку перевірте, чи в полях номерів будинку та квартири введені натуральні числа.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void error5_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Під час намагання програми знайти людей, використовуючи критерії прізвища, було визначено, що користувач не заповнив поле.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void error6_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("В головному списку не було знайдено записів, що відповідають критерію пошуку.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void error7_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Під час додавання запису, було визначено, що в списку вже є людина з таким же ідентифікатором, змініть його, або видаліть існуючий запис.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void error8_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Під час спроби зберегти зміни в редагованому файлі виявилось, що він був стертий з диску або переміщений. Оберіть функцію Файл->Зберегти як… .");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }

        private void error9_Selected(object sender, RoutedEventArgs e)
        {
            Run content = new Run("Під час спроби записати список в текстовий файл сталась помилка. Оберіть інший файл.");
            this.paragraph.Inlines.Clear();
            this.paragraph.Inlines.Add(content);
        }
    }
}
