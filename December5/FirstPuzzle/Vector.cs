public class Vector
{
    (int, int) _coordOne { get; set; }

    (int, int) _coordTwo { get; set; }

    List<string> AllPoints = new List<string>();

    bool _direction { get; set; }

    bool PlusOrMinus = true;

    //int _x1, int _y1, int _x2, int _y2
    public Vector()
    {

    }

    public (int, int) CoordOne
    {
        get => _coordOne;

        set => _coordOne = value;
    }

    public (int, int) CoordTwo
    {
        get => _coordTwo;
        set => _coordTwo = value;
    }

    public bool Direction
    {
        get => _direction;
    }

    public List<string> getPoints()
    {
        setPoints();
        return AllPoints;
    }

    private void setPoints()
    {
        if (_coordOne.Item1 == _coordTwo.Item1)
        {
            Console.WriteLine("Vertical:");
            int maxLength = getVerticalMax();
            Console.WriteLine(_coordOne.Item1 + "," + _coordOne.Item2);
            AllPoints.Add(_coordOne.Item1 + "," + _coordOne.Item2);

            if (PlusOrMinus)
            {
                for (int i = _coordOne.Item2 + 1; i < maxLength; i++)
                {
                    Console.WriteLine(_coordOne.Item1 + "," + i);
                    AllPoints.Add((_coordOne.Item1 + "," + i));
                }
                Console.WriteLine(_coordTwo.Item1 + "," + _coordTwo.Item2);
                AllPoints.Add(_coordTwo.Item1 + "," + _coordTwo.Item2);
            }
            else
            {
                for (int i = _coordOne.Item2 - 1; i < maxLength; i--)
                {
                    Console.WriteLine(_coordOne.Item1 + "," + i);
                    AllPoints.Add((_coordOne.Item1 + "," + i));
                }
                Console.WriteLine(_coordTwo.Item1 + "," + _coordTwo.Item2);
                AllPoints.Add(_coordTwo.Item1 + "," + _coordTwo.Item2);
            }


        }
        else if (_coordOne.Item2 == _coordTwo.Item2)
        {
            Console.WriteLine("Horizon:");
            int maxLength = getHorizontalMax();



            if (PlusOrMinus)
            {
                Console.WriteLine(_coordOne.Item1 + "," + _coordOne.Item2);
                AllPoints.Add(_coordOne.Item1 + "," + _coordOne.Item2);
                for (int i = _coordOne.Item1 + 1; i < maxLength; i++)
                {
                    Console.WriteLine(i + "," + _coordOne.Item2);
                    AllPoints.Add((i + "," + _coordOne.Item2));
                }
                AllPoints.Add(_coordTwo.Item1 + "," + _coordTwo.Item2);
                Console.WriteLine(_coordTwo.Item1 + "," + _coordTwo.Item2);
            }
            else
            {
                Console.WriteLine(_coordTwo.Item1 + "," + _coordTwo.Item2);
                AllPoints.Add(_coordTwo.Item1 + "," + _coordTwo.Item2);

                for (int i = _coordTwo.Item1 + 1; i < maxLength + 1; i++)
                {
                    Console.WriteLine(i + "," + _coordOne.Item2);
                    AllPoints.Add((i + "," + _coordOne.Item2));
                }
                Console.WriteLine(_coordOne.Item1 + "," + _coordOne.Item2);
                AllPoints.Add(_coordOne.Item1 + "," + _coordOne.Item2);
            }



        }
    }

    private int getVerticalMax()
    {
        if (_coordOne.Item2 < _coordTwo.Item2)
        {
            Console.WriteLine("Vert plus");

            return _coordOne.Item2 + _coordTwo.Item2;

        }
        else
        {
            Console.WriteLine("Vert minus");
            PlusOrMinus = false;
            return _coordOne.Item2 - _coordTwo.Item2;
        }
    }

    private int getHorizontalMax()
    {
        if (_coordOne.Item1 < _coordTwo.Item1)
        {
            Console.WriteLine("Hori plus");
            return _coordOne.Item1 + _coordTwo.Item1;
        }
        else
        {
            Console.WriteLine("Hori minus");
            PlusOrMinus = false;
            return _coordOne.Item1 - _coordTwo.Item1;
        }
    }
}