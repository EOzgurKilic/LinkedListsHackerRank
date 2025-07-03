using System.Collections;

namespace LinkedListsHackerRank;

class Program
{
    static void Main(string[] args)
    {
        //The question solutions are in the other project in the solution. In this one, We have generated an example LinkedList source code...
        //... and a proper custom IEnumerator<> class to it, made the foreach statement usage available for our example linked list class...
        //.. by implementing IEnumerable<> in the source code, and gave some terms&definitions.
        
        //Terminology
        //Head: The first node in a linked list.
        //Tail: The last node in a linked list.
        //Pointer: Reference to another node.
        //Node: An object containing data and pointer(s)
        //Constant Time = O(1), Linear Time = O(n)
        
        ExpLinkedList<int> list1 = new ExpLinkedList<int>();
        list1.AddNode(10);
        list1.AddNode(15);
        list1.AddNode(14);
        list1.AddNode(17);
        
        foreach(var node in list1)
            Console.WriteLine(node);
        
        ExpLinkedList<string> list2 = new ExpLinkedList<string>();
        list2.AddNode("efe");
        list2.AddNode("ozgur");
        list2.AddNode("kilic");
        list2.AddNode("Orkhan");
        list2.AddNode("Rahimli");
        list2.Reverse();
        
        foreach(var node in list2)
            Console.WriteLine(node);
    }
}

class ExpNode<T>
{
    T data;
    public T Value { get => data; }
    ExpNode<T> next;
    public ExpNode<T> Next {
        get{return next;}
        set { next = value; }
    }

    public ExpNode(T data)
    {
        this.data = data; 
        next = null;
    }
}

class ExpLinkedList<T> : IEnumerable<T>
{
    private T firstValue;
    ExpNode<T> head;
    public ExpNode<T> First {get {return head;}}
    private int counter = 0;

    public ExpLinkedList()
    {
        head = null;
    }

    public void AddNode(T data)
    {
        ExpNode<T> node = new ExpNode<T>(data);
        node.Next = head;
        head = node;
        counter++;
    }

    public int Count()
    {
        return counter;
    }

    public void Reverse()
    {
        ExpNode<T> prev = null;
        ExpNode<T> current = head;
        ExpNode<T> next = null;

        while (current != null)
        {
            next = current.Next;    
            current.Next = prev;   
            prev = current;        
            current = next;
        }

        head = prev;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new ExpLinkedListEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}

class ExpLinkedListEnumerator<T> : IEnumerator<T>
{
    private ExpLinkedList<T> _source;
    ExpNode<T> _current;
    public ExpLinkedListEnumerator(ExpLinkedList<T> source)
    {
        _source = source;
        _source.AddNode(default);
        _current = _source.First;
    }
    
    public T Current
    {
        get { return _current.Value; }
    }

    object? IEnumerator.Current
    {
        get { return _current.Value; }
    }

    public bool MoveNext()
    { 
        _current = _current.Next;
        return _current != null;
    }

    public void Reset()
    {
        _current = _source.First;
    }

    public void Dispose()
    {
        _source = null;
    }
}