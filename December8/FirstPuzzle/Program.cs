using System.Linq;
public class Program
{

    static List<int> numbers = new List<int>();

    static string[] words;

    static string decodeString;

    static string[] decode;

    static string[] letters = new string[10];



    public static void Main()
    {
        foreach (var item in System.IO.File.ReadLines(@"../input.txt"))
        {
            string[] line = item.Split(" | ");



            decodeString = line[0];

            decode = line[0].Split(" ");

            words = line[1].Split(" ");


            Array.Sort(decode, (x, y) => x.Length.CompareTo(y.Length));

            for (int i = 0; i < words.Length; i++)
            {

                words[i] = sortString(words[i]);
            }

            // Array.Sort(words, (x, y) => String.Compare(x, y));





            // for (int j = 0; j < word.Length; j++)
            // {
            //     switch (word[j].Length)
            //     {
            //         case 2: digits[1] = word[j];
            //         case 3: digits[7] = word[j];
            //         case 4: digit[4] = word[j];
            //         case 7: digits[8] = word[j];
            //         default:
            //     }
            // }

            // for (int j = 0; j < word.Length; j++)
            // {

            //     word[j] = String.Concat(word[j].OrderBy(c => c));
            //     //Console.WriteLine("Word:" + word[j] + " Count:" + word[j].Length);
            //     switch (word[j])
            //     {
            //         case "abcdeg": tal += "0"; break;
            //         case "ab": tal += "1"; break;
            //         case "acdfg": tal += "2"; break;
            //         case "abcdf": tal += "3"; break;
            //         case "abef": tal += "4"; break;
            //         case "bcdef": tal += "5"; break;
            //         case "bcdefg": tal += "6"; break;
            //         case "abd": tal += "7"; break;
            //         case "abcdefg": tal += "8"; break;
            //         case "abcdef": tal += "9"; break;
            //         default:
            //             break;
            //     };

            //     if (tal.Length == 4)
            //     {
            //         Console.WriteLine(tal);
            //         numbers[index] = tal;
            //         index++;
            //         tal = "";
            //     }


            // }


            // foreach (var number in decode)
            // {

            //     //total += Convert.ToInt32(number);

            //     Console.WriteLine(number);
            // }
            checkAlphabet();
            decodeKnown();
            decodeLength();
            FinalLetter();
            convertToIndex();

            string final = "";
            var sb = new System.Text.StringBuilder();
            foreach (var word in words)
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    if (word.Equals(letters[i]))
                    {
                        final += i.ToString();
                        //sb.Append(i.ToString());
                    }

                }

            }
            //Console.WriteLine(sb.ToString());
            var finalInt = Int32.Parse(final);
            //Console.WriteLine(finalInt);

            numbers.Add(finalInt);
           
        }

        int done = 0;
        foreach (var item in numbers)
        {
            done += item;
        }
        Console.WriteLine(done);
    }

    
    static int[] alphabet;
    static string[] positions;
    //Hold how many times a letter is represented. 

    public static void checkAlphabet()
    {
        alphabet = new int[7];
        for (int j = 0; j < decodeString.Length; j++)
        {
            switch (decodeString.Substring(j, 1))
            {
                case "a": alphabet[0]++; break;
                case "b": alphabet[1]++; break;
                case "c": alphabet[2]++; break;
                case "d": alphabet[3]++; break;
                case "e": alphabet[4]++; break;
                case "f": alphabet[5]++; break;
                case "g": alphabet[6]++; break;
                default: break;
            }
        }

        // foreach (var item in alphabet)
        // {
        //     Console.WriteLine(item);
        // }
    }

    public static void decodeKnown()
    {
        positions = new string[7];
        for (int j = 0; j < alphabet.Length; j++)
        {
            switch (alphabet[j])
            {
                case 4: positions[4] = getLetter(j); break;
                case 6: positions[1] = getLetter(j); break;
                case 9: positions[5] = getLetter(j); break;
                default: break;
            }
        }
        // foreach (var item in positions)
        // {
        //     Console.WriteLine(item);
        // }
    }

    public static void decodeLength()
    {
        for (int i = 0; i < decode.Length; i++)
        {
            switch (decode[i].Length)
            {
                case 2:
                    {
                        string check = positions[5];
                        foreach (var chartmp in decode[i])
                        {
                            if (!check.Contains(chartmp))
                            {
                                positions[2] = chartmp.ToString();
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        // if (positions[0] == " ")
                        // {

                        string check = positions[2] + positions[5];
                        foreach (var chartmp in decode[i])
                        {
                            if (!check.Contains(chartmp))
                            {
                                positions[0] = chartmp.ToString();
                            }
                        }
                        //}
                        // else
                        // {
                        //     string check = positions[0] + positions[2];
                        //     string[] array = decode[i].ToCharArray();
                        //     for (int j = 0; j < array.Length; j++)
                        //     {
                        //         if (!check.Contains(j))
                        //         {
                        //             positions[5] = j;
                        //         }
                        //     }
                        // }
                        break;
                    }
                case 4:
                    {
                        string check = positions[1] + positions[2] + positions[5];

                        foreach (var chartmp in decode[i])
                        {
                            if (!check.Contains(chartmp))
                            {
                                positions[3] = chartmp.ToString();
                            }
                        }
                        break;
                    }
                default: break;
            }
        }

        // foreach (var item in positions)
        // {
        //     Console.WriteLine(item);
        // }
    }

    public static void FinalLetter()
    {
        string check = positions[0] + positions[1] + positions[2] + positions[3] + positions[4] + positions[5];
        string alp = "abcdefg";

        foreach (var chartmp in alp)
        {
            if (!check.Contains(chartmp))
            {
                positions[6] = chartmp.ToString();
            }
        }
        // foreach (var item in positions)
        // {
        //     Console.WriteLine(item);
        // }
    }

    public static void convertToIndex()
    {
        letters = new string[10];

        letters[0] = positions[0] + positions[1] + positions[2] + positions[4] + positions[5] + positions[6];
        letters[1] = positions[2] + positions[5];
        letters[2] = positions[0] + positions[2] + positions[3] + positions[4] + positions[6];
        letters[3] = positions[0] + positions[2] + positions[3] + positions[5] + positions[6];
        letters[4] = positions[1] + positions[2] + positions[3] + positions[5];
        letters[5] = positions[0] + positions[1] + positions[3] + positions[5] + positions[6];
        letters[6] = positions[0] + positions[1] + positions[3] + positions[4] + positions[5] + positions[6];
        letters[7] = positions[0] + positions[2] + positions[5];
        letters[8] = positions[0] + positions[1] + positions[2] + positions[3] + positions[4] + positions[5] + positions[6];
        letters[9] = positions[0] + positions[1] + positions[2] + positions[3] + positions[5] + positions[6];


        for (int i = 0; i < letters.Length; i++)
        {
            letters[i] = sortString(letters[i]);
        }


        // Console.WriteLine("Letters: ");
        // foreach (var item in letters)
        // {
        //     Console.WriteLine(item);
        // }
        // Console.WriteLine("words: ");
        // foreach (var item in words)
        // {
        //     Console.WriteLine(item);
        // }
    }


    public static string getLetter(int index)
    {
        switch (index)
        {
            case 0: return "a"; break;
            case 1: return "b"; break;
            case 2: return "c"; break;
            case 3: return "d"; break;
            case 4: return "e"; break;
            case 5: return "f"; break;
            case 6: return "g"; break;
            default: return " "; break;
        }
    }

    static string sortString(string str)
    {
        char[] arr = str.ToCharArray();
        Array.Sort(arr);
        string done = String.Join("", arr);
        return done;
    }

}
