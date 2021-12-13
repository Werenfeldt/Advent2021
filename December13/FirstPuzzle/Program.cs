// public class Program
// {

//     static List<string> GridList = new List<string>();

//     static string[] Grid = new string[165];

//     static int y;

//     static int x;

//     static int length = 165;



//     public static void Main()
//     {

//         foreach (var item in System.IO.File.ReadLines(@"../test.txt"))
//         {
//             if (item.Contains("fold"))
//             {
//                 string[] coord = item.Split(" ");
//                 string[] tmp = coord[2].Split("=");

//                 if (tmp[0] == "y")
//                 {
//                     y = Int32.Parse(tmp[1]);
//                 }
//                 else
//                 {
//                     x = Int32.Parse(tmp[1]);
//                 }
//             }
//             else if (!string.IsNullOrEmpty(item))
//             {

//                 string[] line = item.Split(",");

//                 var index = (Int32.Parse(line[1]) * 11) + Int32.Parse(line[0]);



//                 Grid[index] = "#";
//             }

//         }

//         for (int i = 0; i < Grid.Length; i++)
//         {
//             if (Grid[i] == null)
//             {
//                 Grid[i] = ".";
//             }
//         }

//         FoldY();
//         FoldX();

//         for (int i = 0; i < Grid.Length; i++)
//         {
//             if (i != 0 && i % x == 0)
//             {
//                 Console.WriteLine();

//             }
//             Console.Write(Grid[i]);
//         }
//     }

//     public static void LoadDifference(string[] tmpArray)
//     {
//         for (int i = 0; i < tmpArray.Length; i++)
//         {
//             if (tmpArray[i] == "#")
//             {
//                 Grid[i] = "#";
//             }
//         }
//     }
//     public static void FoldX()
//     {
//         string[] tmpArray = new string[x * y + 1];
//         int length = x;
//         int row = 0;
//         int rowStartMain;
//         int rowStartTmp;
//         while (row < y)
//         {
//             rowStartMain = (row * 11) + (x + 1);
//             rowStartTmp = (row * x);

//             Array.Copy(Grid, rowStartMain, tmpArray, rowStartTmp, length);

//             row++;
//         }

//         row = 6;
//         rowStartMain = 0;
//         var tmpList = Grid.ToList();

//         while (row > -1)
//         {
//             rowStartMain = (row * 11) + (x);
//             Console.WriteLine(row);
//             Console.WriteLine(rowStartMain);

//             tmpList.RemoveRange(rowStartMain, x + 1);
//             row--;
//         }

//         Grid = tmpList.ToArray();

//         tmpArray = FlipX(tmpArray);

//         LoadDifference(tmpArray);


//         // for (int i = 0; i < Grid.Length; i++)
//         // {
//         //     if (i != 0 && i % 5 == 0)
//         //     {
//         //         Console.WriteLine();

//         //     }
//         //     Console.Write(Grid[i]);
//         // }

//         // Console.WriteLine(" ");
//         // Console.WriteLine(" ");

//         // for (int i = 0; i < tmpArray.Length; i++)
//         // {
//         //     if (i != 0 && i % 5 == 0)
//         //     {
//         //         Console.WriteLine();

//         //     }
//         //     Console.Write(tmpArray[i]);
//         // }
//     }

//     public static void FoldY()
//     {

//         string[] tmpArray = new string[y * 11];
//         int startIndex = (y + 1) * 11;
//         int length = y * 11;
//         Array.Copy(Grid, startIndex, tmpArray, 0, length);

//         tmpArray = FlipY(tmpArray);

//         var tmpList = Grid.ToList();
//         tmpList.RemoveRange(y * 11, (tmpList.Count - y * 11));
//         Grid = tmpList.ToArray();

//         LoadDifference(tmpArray);


//         // for (int i = 0; i < Grid.Length; i++)
//         // {
//         //     if (i != 0 && i % 11 == 0)
//         //     {
//         //         Console.WriteLine();

//         //     }
//         //     Console.Write(Grid[i]);
//         // }

//         // Console.WriteLine(" ");
//         // Console.WriteLine(" ");

//         //int decrease = 11;

//         // for (int i = tmpArray.Length - decrease; i < 12; i++)
//         // {
//         //     if (i != 0 && i % 11 == 0)
//         //     {
//         //         Console.WriteLine();
//         //         decrease = decrease + 11;

//         //     }
//         //     Console.Write(tmpArray[i]);
//         // }



//     }


//     public static string[] FlipX(string[] array)
//     {
//         string[] flip = new string[array.Length];
//         int startIndexArray = 4;
//         int startIndexFlip = 0;
//         int row = 0;
//         int length = 11;

//         for (int i = 0; i < array.Length; i++)
//         {
//             if (i % 5 == 0)
//             {

//                 flip[i] = array[x * row + 4];
//             }
//             else if (i % 5 == 1)
//             {
//                 flip[i] = array[x * row + 3];
//             }

//             row++;

//         }

//         return flip;
//     }

//     public static string[] FlipY(string[] array)
//     {
//         string[] flip = new string[array.Length];
//         int startIndexArray = (array.Length - 11);
//         int startIndexFlip = 0;
//         int length = 11;

//         while (startIndexArray > -11)
//         {
//             Array.Copy(array, startIndexArray, flip, startIndexFlip, length);

//             startIndexArray -= 11;

//             startIndexFlip += 11;

//         }

//         return flip;

//         // for (int i = 0; i < flip.Length; i++)
//         // {
//         //     if (i != 0 && i % 11 == 0)
//         //     {
//         //         Console.WriteLine();

//         //     }
//         //     Console.Write(flip[i]);
//         // }

//     }

// }


