//  создаём пустой список с типом данных Contact
using Task14_3_3.Classes;

var phoneBook = new List<Contact>();

// добавляем контакты
phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));


//В книге содержится 6 записей.
//Реализуйте для неё постраничный вывод, по 2 записи на страницу. Работать это должно следующим образом
//Пользователь вводит номер страницы от 1 до 3 с консоли (получить можно через Console.ReadKey().KeyChar;).
//Программа выводит записи с этой страницы (к примеру, если введёт 2, то должно показать Анатолия и Валерия).
//После работы программа не завершается, а снова ожидает ввод.

//Практика
//Доработайте вашу телефонную книгу из задания 14.2.10 предыдущего юнита так, чтобы контакты телефонной книги 
//были отсортированы сперва по имени, а затем по фамилии.

Console.WriteLine("Выводим несортированную телефонную книгу: ");
foreach(Contact ct in phoneBook)
{
    Console.WriteLine("Имя: " + ct.Name + ", Фамилия: " + ct.LastName + ", Телефон: " + ct.PhoneNumber + ", E-mail: " + ct.Email);
}
Console.WriteLine();



var sortPhoneBook = from contact in phoneBook
                    orderby contact.Name, contact.LastName
                    select contact;

Console.WriteLine("Выводим отсортированную телефонную книгу: ");
foreach (Contact ct in sortPhoneBook)
{
    Console.WriteLine("Имя: " + ct.Name + ", Фамилия: " + ct.LastName + ", Телефон: " + ct.PhoneNumber + ", E-mail: " + ct.Email);
}
Console.WriteLine();


while (true)
{
    try
    {
        Console.WriteLine("Для просмотра записей телефонной книги, введие целое число, начиная с 1, либо введите Exit, для выхода: ");
        
        // Считываем данные, введенные Пользователем
        string checkForExit = Console.ReadLine();

        // Проверяем, не ввел ли Пользователь слово Exit, если ввел, выходим из цикла
        if (checkForExit == "Exit")
        {
            break;
        }
        
        // Пытаемся конвертировать полученные данные от Пользователя в целое число
        int pageNumber = Convert.ToInt32(checkForExit);

        Console.Clear();

        // Проверяем, соответствует ли число введенное Пользователем, количеству страниц в телефонной книге
        if (pageNumber > 0 && pageNumber <= sortPhoneBook.Count())
        {
            var partOfContact = sortPhoneBook.Skip(pageNumber * 2 - 2).Take(2);

            Console.WriteLine("Содержание " + pageNumber + " страницы:");

            foreach (Contact contact in partOfContact)
            {
                Console.WriteLine("Имя: " + contact.Name + ", Фамилия: " + contact.LastName + ", Телефон: " + contact.PhoneNumber + ", E-mail: " + contact.Email);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Введенное число, больше чем пар записей в телефонной книге.");
            Console.WriteLine();
        }

    }
    catch (Exception e)
    {
        Console.Clear();
        Console.WriteLine(e.Message);
        Console.WriteLine();
    }
}   
