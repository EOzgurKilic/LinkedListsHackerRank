using System.Collections;

namespace LinkedListsHackerRank;

class Program
{
    static void Main(string[] args)
    {
        //Terminology
        //Head: The first node in a linked list.
        //Tail: The last node in a linked list.
        //Pointer: Reference to another node.
        //Node: An object containing data and pointer(s)
        //Constant Time = O(1), Linear Time = O(n)
        
    }
}

class ExpNode
{
    int data;
    ExpNode next;
    public ExpNode Next {
        get{return next;}
        set { next = value; }
    }

    public ExpNode(int x)
    {
        this.data = data;
        ExpNode next = null;
    }
}

class ExpLinkedList : IEnumerable<ExpNode>
{
    ExpNode head;
    private int counter = 0;

    public ExpLinkedList()
    {
        head = null;
    }

    public void AddNode(int data)
    {
        ExpNode node = new ExpNode(data);
        node.Next = head;
        head = node;
        counter++;
    }

    public IEnumerator<ExpNode> GetEnumerator()
    {
        return new LinkedList<ExpNode>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        
    }

}

class ExpLinkedListEnumerator : IEnumerator<ExpNode>
{
    public ExpNode Current { get; }

    object? IEnumerator.Current { get; }
    
    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}