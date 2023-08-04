int number;                             //variable to check the input number of rows for the data type

int CheckForNumber(int i = 5)           //method for checking the data type when entering the number of array rows and limiting the input of invalid values
{
    Console.Write("Введите длинну массива: ");
    String lengts = Console.ReadLine();
    bool success = int.TryParse(lengts, out number);
    if (success)
    {
        return number;
    }
    else
    {
        if (i < 1)
        {
            Console.WriteLine($"Введено не числовое значение '{lengts ?? "<null>"}', ошибка ввода.");
            return number;
        }
        else
        {
            Console.WriteLine($"Введено не числовое значение '{lengts ?? "<null>"}', ошибка ввода. Осталось {i} попыток ввода.");
            return CheckForNumber(i - 1);
        }
    }
}

int lengts = CheckForNumber(5);

string[] CreatArray(int length)              //array creation method
{
    string[] sourseArray = new string[length];
    for (int i = 0; i < length; i++)
    {
        Console.Write($"Осталось ввести {length - i} значений строк массива. \nВведите значение {i + 1} строки массива: ");
        sourseArray[i] = Console.ReadLine();
    }
    return sourseArray;
}

string[] ChangeArray(int newLength, out int countDataRecorder, string[] sourseArray)        //array change method
{
    string[] newArray = new string[newLength];
    int tempCount = 0;                                      //variable to get the number of filled array rows from the method
    for (int i = 0, j = 0; i < newLength; i++)
    {

        string temp = sourseArray[i];
        if (temp.Length <= 3)
        {
            newArray[j] = sourseArray[i];
            j++;
            tempCount = j;
        }
    }
    countDataRecorder = tempCount;
    return newArray;
}
int countDataRecorder;
void PrintArray(string[] sourseArray)               //array print method
{
    Console.Write($"{string.Join("; ", sourseArray)}\n");
}

if (number == 0)
{
    Console.WriteLine($"Вы превысилили лимит попыток ввода количества строк, либо ввели 0 строк для массива.");
}

else if (number == 1)
{
    Console.WriteLine($"Вы ввели 1 строку для массива. Массив строк не может состоять из 1 строки!");
}

else
{
    string[] sourseArray = CreatArray(lengts);                                              //create initial array
    int newLenght = sourseArray.Length;
    string[] tempArray = ChangeArray(newLenght, out countDataRecorder, sourseArray);        //create an intermediate array of the same length
    string[] newArray = ChangeArray(countDataRecorder, out countDataRecorder, tempArray);   //create final array without empty strings
    Console.WriteLine($"В массиве: ");
    PrintArray(sourseArray);
    if (countDataRecorder == 0)
    {
        Console.WriteLine($"нет строк, имеющих длинну не более 3х символов.");
    }
    else
    {
        Console.WriteLine($"следующие строки имеют длинну не более 3х символов: ");
        PrintArray(newArray);
    }
}