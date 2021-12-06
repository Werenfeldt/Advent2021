public class Node{
    public int number{get; set;}
    public bool drawn{get; set;}

    public Node(int _number){
        this.drawn = false;
        this.number = _number;
    }

    public void NodeIsDrawn(){
        this.drawn = true;
    }
}