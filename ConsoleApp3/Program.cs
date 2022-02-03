namespace Almaz_lessons_app
{
    public class Program
    {
       static void Main(string[] args)
        {
            Figure[] figures = Figure.CreateFigureArr(10);
            foreach (Figure f in figures)
            {
                f.PrintInfo();
            }
            Console.WriteLine("----");
            figures = I2DFigure.FindMaxSquareFigures(figures);
            foreach (Figure f in figures)
            {
                f.PrintInfo();
                I2DFigure i2DFigure=(I2DFigure)f;
                Console.WriteLine(i2DFigure.GetSquare());
                
            }

        }
    }
}



//static int customPow(int numBase, int degree)
//{
//    if (degree == 0) return 1;
//    int res = numBase;
//    for (int i = 1; i < degree; i++)
//    {
//        res *= numBase;
//    }
//    return res;
//}


//static string JumpingNumber(int number)
//{

//    string isJumping = "Jumping!!";
//    string notJumping = "Not!!";

//    if (number < 10) return isJumping;

//    int currentNum = number % 10;
//    int iter = 1;

//    while (iter < number.ToString().Length)
//    {
//        int nextNum = (number / customPow(10, iter) % 10);
//        Console.WriteLine("curNum: " + currentNum + " nexNum: " + nextNum + " iter: " + customPow(10, iter));
//        if ((currentNum - nextNum) != 1)
//        {
//            if ((currentNum - nextNum != (-1)))
//            {
//                Console.WriteLine("NOT");
//                return notJumping;
//            }
//        }

//        currentNum = nextNum;
//        iter++;
//    }
//    return isJumping;
//}

//static string SpecialNumber(int number)
//{
//    int[] validNums = { 0, 1, 2, 3, 4, 5 };
//    string isSpecial = "Special!!";
//    string notSpecial = "NOT!!";

//    int iter = 0;

//    while (iter < number.ToString().Length)
//    {
//        int nextNum = (number / customPow(10, iter) % 10);
//        Console.WriteLine(" nexNum: " + nextNum + " iter: " + customPow(10, iter));

//        bool isValid = false;
//        foreach (int num in validNums)
//        {
//            if (nextNum == num)
//            {
//                isValid = true;
//                break;
//            }
//        }
//        if (!isValid) return notSpecial;
//        iter++;
//    }
//    return isSpecial;
//}



//static string BalancedNumber(int number)
//{
//    string isBalanced = "Balanced";
//    string notBalanced = "Not Balanced";

//    int numLen = number.ToString().Length;
//    bool isOdd = numLen % 2 == 0;

//    if (numLen == 1) return isBalanced;
//    if (numLen == 2) return isBalanced;
//    Console.WriteLine(number);

//    int rightPart = 0;
//    for (int i = 0; i < (numLen / 2) - (isOdd ? 1 : 0); i++)
//    {
//        int nextNum = (number / customPow(10, i) % 10);
//        Console.WriteLine("i right=" + i + " nextNum=" + nextNum);
//        rightPart += nextNum;
//    }

//    int leftPart = 0;
//    for (int i = numLen - 1; i > numLen / 2; i--)
//    {
//        int nextNum = (number / customPow(10, i) % 10);
//        Console.WriteLine("i left=" + i + " nextNum=" + nextNum);
//        leftPart += nextNum;
//    }

//    Console.WriteLine("leftPart=" + leftPart + " rightPart=" + rightPart);
//    if (rightPart != leftPart) return notBalanced;

//    return isBalanced;
//}

//static int MaxNumber(int n)
//{
//    int numLen = n.ToString().Length;
//    if (n == 1) return n;

//    int iter = 0;
//    int[] numsArr = { };
//    while (iter < numLen)
//    {
//        int nextNum = (n / customPow(10, iter) % 10);
//        int[] newArr = new int[numsArr.Length + 1];
//        for (int i = 0; i < numsArr.Length; i++)
//        {
//            newArr[i] = numsArr[i];
//        }
//        newArr[newArr.Length - 1] = nextNum;
//        numsArr = newArr;
//        iter++;
//    }
//    int temp;
//    for (int i = 0; i < numsArr.Length; i++)
//    {
//        for (int j = i + 1; j < numsArr.Length; j++)
//        {
//            if (numsArr[i] < numsArr[j])
//            {
//                temp = numsArr[i];
//                numsArr[i] = numsArr[j];
//                numsArr[j] = temp;
//            }
//        }
//    }
//    temp = numsArr.Length - 1;
//    int result = 0;
//    for (int i = 0; i < numsArr.Length; i++)
//    {
//        result = result + (numsArr[i] * customPow(10, temp));
//        temp--;
//    }
//    return result;



//}


//static int[][] MatrixAddition(int[][] a, int[][] b)
//{
//    int n = a.Length;
//    int[][] result = new int[n][];
//    for (int i = 0; i < n; i++)
//    {
//        result[i] = new int[n];
//    }

//    for (int i = 0; i < n; i++)
//    {
//        for (int j = 0; j < n; j++)
//        {
//            int temp = a[i][j] + b[i][j];
//            result[i][j] = temp;
//        }
//    }

//    return result;
//}

//int[][] matrix1 = new int[3][];
//matrix1[0] = new int[3] { 1, 2, 3 };
//matrix1[1] = new int[3] { 1, 2, 3 };
//matrix1[2] = new int[3] { 1, 2, 3 };

//int[][] matrix2 = new int[3][];
//matrix2[0] = new int[3] { 1, 2, 3 };
//matrix2[1] = new int[3] { 1, 2, 3 };
//matrix2[2] = new int[3] { 1, 2, 3 };




//static (int, int)[] TwosDifference(int[] array)
//{
//    (int, int)[] result = { };

//    foreach (int arg1 in array)
//    {
//        foreach (int arg2 in array)
//        {
//            if (arg1 - arg2 == 2)
//            {
//                (int, int)[] newResult = new (int, int)[result.Length + 1];
//                for (int i = 0; i < result.Length; i++)
//                {
//                    newResult[i] = result[i];
//                }
//                newResult[result.Length] = (arg2, arg1);
//                result = newResult;
//            }
//        }
//    }

//    (int, int) temp;

//    for (int i = 0; i < result.Length; i++)
//    {
//        for (int j = i + 1; j < result.Length; j++)
//        {
//            if (result[i].Item1 > result[j].Item1)
//            {
//                temp = result[i];
//                result[i] = result[j];
//                result[j] = temp;
//            }
//        }
//    }

//    return result;
//}




//static int ShortestStepsToNum(int num)
//{
//    int stepsCount = 0;
//    int temp = num;

//    while (temp != 1)
//    {
//        stepsCount++;
//        switch (temp % 2 == 0)
//        {
//            case true:
//                temp = temp / 2;
//                break;
//            case false:
//                temp = temp - 1;
//                break;
//        }
//    }

//    return stepsCount;
//}



//static string Swap(string s)
//{
//    string vowels = "aeiou";
//    foreach (char c in vowels)
//    {
//        s = s.Replace(c, Char.ToUpper(c));
//    }
//    return s;
//}

//static bool Solution1(string str, string ending)
//{
//    return str.EndsWith(ending);

//}

//static string Balance(string book)
//{

//    book = System.Text.RegularExpressions.Regex.Replace(book, "[!,?;:=}{]", "");
//    book = book.Replace("\r\n", "\n");
//    book = book.Replace(".", ",");


//    string[] bookArr = book.Split('\n');

//    string firstLine = $"Original_Balance: {bookArr[0]}";
//    book = book.Replace(bookArr[0].ToString(), firstLine);

//    double balance = double.Parse(bookArr[0]);
//    double totalExpense = 0;

//    foreach (string line in bookArr)
//    {
//        string newLine = System.Text.RegularExpressions.Regex.Replace(line, @"\s+", " ");
//        string[] args = newLine.Split(" ");
//        if (args.Length <= 1)
//            continue;

//        double price = double.Parse(args[2]);
//        totalExpense += price;
//        //balance = System.Math.Round((balance-price),2);
//        balance = balance - price;
//        string strBalance = string.Format("{0:F2}", balance);
//        newLine = $"{newLine} Balance {strBalance}";
//        book = book.Replace(line, newLine);
//    }

//    string strTotalExpense = string.Format("{0:F2}", totalExpense);
//    string strAverageExpence = string.Format("{0:F2}", totalExpense / (bookArr.Length - 1));
//    book = book.Insert(book.Length, $"\nTotal expense  {strTotalExpense}\n");
//    book = book.Insert(book.Length, $"Average expense  {strAverageExpence}");
//    book = book.Replace(",", ".");
//    return book;

//}



////string b1 = "1233.00\n125 Hardware;! 24.80?\n123 Flowers 93.50;\n127 Meat 120.90\n120 Picture 34.00\n124 Gasoline 11.00\n" +
////                    "123 Photos;! 71.40?\n122 Picture 93.50\n132 Tyres;! 19.00,?;\n129 Stamps; 13.60\n129 Fruits{} 17.60\n129 Market;! 128.00?\n121 Gasoline;! 13.60?";
////Console.WriteLine(Balance(b1));

//static string AlphabetPosition(string text)
//{
//    text = text.ToLower();
//    string letters = String.Join("", System.Linq.Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray());
//    string result = "";

//    foreach (char c in text)
//    {
//        int index = letters.IndexOf(c);
//        if (index == -1) continue;
//        result = $"{result} {index}";
//    }

//    return result.Trim();
//}

////AlphabetPosition("The sunset sets at twelve o' clock.");

