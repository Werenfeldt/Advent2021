public class Vector
{
    (int, int) _coordOne {get; set;}
    (int, int) _coordTwo {get; set;}

    //altid laveste først og item1 dominerer
    //0= hori
    //1 = vert
    //2 == diagonal where one.item1 < two.item1 && one.item2 < two.item2: plus alle
    //3 == diagonal where one.item1 < two.item1 && one.item2 > two.item2: plus item 1 minus item 2
    int horizontal = 0;
    List<string> AllPoints = new List<string>();



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

    public int GetDirection(){
        return horizontal;
    }

    public void SetDirection(){
    
        if(CoordOne.Item1 == CoordTwo.Item1){
           
            //Console.WriteLine(CoordOne.Item1 + "," + CoordTwo.Item1);
            horizontal = 1;
        } else if(_coordOne.Item2 == _coordTwo.Item2){
            
            //Console.WriteLine(_coordOne.Item2 + "," + _coordTwo.Item2);
            horizontal = 0;
        } else if(CoordOne.Item1 < CoordTwo.Item1 && CoordOne.Item2 < CoordTwo.Item2){
            horizontal = 2;
        } else if(CoordOne.Item1 < CoordTwo.Item1 && CoordOne.Item2 > CoordTwo.Item2){
            horizontal = 3;
        }
    }

     public void SetRightOrder(){
        if(_coordOne.Item1 == _coordTwo.Item1){

            if(_coordOne.Item2 > _coordTwo.Item2){
                var tmp = _coordOne;
                _coordOne = _coordTwo;
                _coordTwo = tmp;
            }
            //Console.WriteLine(CoordOne.Item1 + "," + CoordOne.Item2 + " -> " + CoordTwo.Item1 + "," + CoordTwo.Item2);

        } else if(_coordOne.Item2 == _coordTwo.Item2){
            if(_coordOne.Item1 > _coordTwo.Item1){
                var tmp = _coordOne;
                _coordOne = _coordTwo;
                _coordTwo = tmp;
            }
            //Console.WriteLine(CoordOne.Item1 + "," + CoordOne.Item2 + " -> " + CoordTwo.Item1 + "," + CoordTwo.Item2);
        } else {
            if(CoordOne.Item1 > CoordTwo.Item1 && CoordOne.Item2 > CoordTwo.Item2){
                var tmp = _coordOne;
                _coordOne = _coordTwo;
                _coordTwo = tmp;
                 //Console.WriteLine(CoordOne.Item1 + "," + CoordOne.Item2 + " -> " + CoordTwo.Item1 + "," + CoordTwo.Item2);
            } else if(CoordOne.Item1 > CoordTwo.Item1 && CoordOne.Item2 < CoordTwo.Item2){
                var tmp = _coordOne;
                _coordOne = _coordTwo;
                _coordTwo = tmp;
                //Console.WriteLine(CoordOne.Item1 + "," + CoordOne.Item2 + " -> " + CoordTwo.Item1 + "," + CoordTwo.Item2);
            }
        }
    }

      private int getVerticalMax()
    {
        //Console.WriteLine(CoordTwo.Item2 + "-" + CoordOne.Item2);
        return CoordOne.Item2 + (CoordTwo.Item2 - CoordOne.Item2);
    }

    private int getHorizontalMax()
    {
        //Console.WriteLine(CoordTwo.Item1 +"-" +CoordOne.Item1);
        return CoordOne.Item1 + (CoordTwo.Item1 - CoordOne.Item1);
    }

    private int getDiagonal(){
        return CoordOne.Item1 + (CoordTwo.Item1 - CoordOne.Item1);
    }

    


    public List<string> getPoints()
    {
        setPoints();
        return AllPoints;
    }

   

    private void setPoints()
    {
        SetRightOrder();
        SetDirection();
        if (GetDirection() == 1)
        {
            //Console.WriteLine("Vertical:");
            int maxLength = getVerticalMax();
            //Console.WriteLine(CoordOne.Item1 + "," + CoordOne.Item2);
            AllPoints.Add(CoordOne.Item1 + "," + CoordOne.Item2);

    
            for (int i = CoordOne.Item2 + 1; i < maxLength; i++)
            {
               //Console.WriteLine(CoordOne.Item1 + "," + i);
                AllPoints.Add((CoordOne.Item1 + "," + i));
            }
            //Console.WriteLine(CoordTwo.Item1 + "," + CoordTwo.Item2);
            AllPoints.Add(CoordTwo.Item1 + "," + CoordTwo.Item2);
    

        }
        else if (GetDirection() == 0)
        {
            //Console.WriteLine("Horizon:");
            int maxLength = getHorizontalMax();

                //Console.WriteLine(CoordOne.Item1 + "," + CoordOne.Item2);
                AllPoints.Add(CoordOne.Item1 + "," + CoordOne.Item2);
                for (int i = CoordOne.Item1 + 1; i < maxLength; i++)
                {
                   //Console.WriteLine(i + "," + CoordOne.Item2);
                    AllPoints.Add((i + "," + CoordOne.Item2));
                }
                AllPoints.Add(CoordTwo.Item1 + "," + CoordTwo.Item2);
                //Console.WriteLine(CoordTwo.Item1 + "," + CoordTwo.Item2);
         
        } else if (GetDirection() == 2){
            int maxLength = getDiagonal();

            //Console.WriteLine("Diag 2:");


            //Console.WriteLine(CoordOne.Item1 + "," + CoordOne.Item2);
            AllPoints.Add(CoordOne.Item1 + "," + CoordOne.Item2);

            int second = CoordOne.Item2 + 1;

            for (int i = CoordOne.Item1 + 1 ; i < maxLength; i++)
            {
                //Console.WriteLine(i + "," + second);
                AllPoints.Add(i + "," + second);
                second++;
                
            }
            //Console.WriteLine(CoordTwo.Item1 + "," + CoordTwo.Item2);
            AllPoints.Add(CoordTwo.Item1 + "," + CoordTwo.Item2);

        } else if (GetDirection() == 3){
            int maxLength = getDiagonal();
             //Console.WriteLine("Diag 3:");


            //Console.WriteLine(CoordOne.Item1 + "," + CoordOne.Item2);
            AllPoints.Add(CoordOne.Item1 + "," + CoordOne.Item2);

            int second = CoordOne.Item2 - 1;

            for (int i = CoordOne.Item1 + 1 ; i < maxLength; i++)
            {
                
                //Console.WriteLine(i + "," + second);
                AllPoints.Add(i + "," + second);
                second--;
                
            }

            AllPoints.Add(CoordTwo.Item1 + "," + CoordTwo.Item2);
            //Console.WriteLine(CoordTwo.Item1 + "," + CoordTwo.Item2);

        }
    }

}