Console.WriteLine("Hello!");

// List to store to do 
List<string> list = new List<string>() { "buy cake", "go shopping", "go fishing" };

bool isUsingToDo = true;
while (isUsingToDo)
{
    Console.WriteLine("Please select your options: ");
    Console.WriteLine("D) Display todo list");
    Console.WriteLine("A) Add a todo");
    Console.WriteLine("R) Remove a todo");
    Console.WriteLine("E) Exit");

    string userchoice = Console.ReadLine();

    if (userchoice.ToUpper() == "D")
    {
        if (!ListIsEmpty(list.Count))
        {
            DisplayToDo();
        }
        Console.WriteLine("");
    }
    else if (userchoice.ToUpper() == "A")
    {
        if (!ListIsEmpty(list.Count))
        {
            AddingToDo();
        }
        Console.WriteLine("");
    }
    else if (userchoice.ToUpper() == "R")
    {
        // if list is not empty, run inside code
        if (!ListIsEmpty(list.Count))
        {
            RemovingToDo();
        }
        Console.WriteLine("");
    }
    else if (userchoice.ToUpper() == "E")
    {
        // exit out the loop thus closing the program
        Console.WriteLine("\nPress any key to exit");
        break;
    }
    else
    {
        Console.WriteLine("\nTry again.");
    }
}

Console.ReadKey();

bool ListIsEmpty(int numOfElement)
{
    if (numOfElement == 0)
    {
        Console.WriteLine("Todo list is empty.");
        return true;
    }
    return false;
}

void RemovingToDo()
{
    bool removing = true;
    while (removing)
    {
        Console.WriteLine("Which list number do you want to remove?");

        DisplayToDo();

        string userRemove = Console.ReadLine();

        // if number is greater than the number of element or input is not a number
        if (list.Count() < ParseToNumber(userRemove) || !IsNumber(userRemove))
        {
            Console.WriteLine("Invalid index.");
            continue;
        }
        else
        {
            // print first so it knows which element is being removed 
            Console.WriteLine($"\"{list[ParseToNumber(userRemove) - 1]}\" is successfully remove.");

            // userRemove - 1 allows us to remove at the 0 index when picking one
            list.Remove(list[ParseToNumber(userRemove) - 1]);
            break;
        }
    }
}

void AddingToDo()
{
    bool adding = true;
    while (adding)
    {
        Console.WriteLine("What do you want to add?");

        string addTodo = Console.ReadLine();

        if (list.Contains(addTodo))
        {
            Console.WriteLine("Can't have duplicate.");
            Console.WriteLine("");
            continue;
        }
        else if (addTodo == "")
        {
            Console.WriteLine("List can not be empty.");
            Console.WriteLine("");
            continue;
        }
        else
        {
            list.Add(addTodo);

            Console.WriteLine($"TODO sucessfully added: {addTodo}");
            Console.WriteLine("");
            break;
        }
    }
}
void DisplayToDo()
{
    int i = 1;
    foreach (string item in list)
    {
        Console.WriteLine($"{i++}. {item}");
    }
}

bool IsNumber(string userNumber)
{
    // if string is a number, true
    if (int.TryParse(userNumber, out int ignoreNum))
    {
        return true;
    }
    return false;
}

int ParseToNumber(string number)
{
    if (int.TryParse(number, out int num))
    {
        return num;
    }
    // 0 if not number
    return 0;
}
