
public class IList
{

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public static void Main(string[] args)
    {
        DoublyLinkedList<int> listA = new DoublyLinkedList<int>();
        listA.Insert(1);
        listA.Insert(3);
        listA.Insert(5);
        listA.Insert(7);
        listA.Insert(9);

        DoublyLinkedList<int> listB = new DoublyLinkedList<int>();
        listB.Insert(2);
        listB.Insert(4);
        listB.Insert(6);
        listB.Insert(8);

        DoublyLinkedList<int> listC = MergeSort(listA, listB, SortDirection.Ascending);
        listC.Print();
    }

    public static DoublyLinkedList<int> Invert(DoublyLinkedList<int> List)
    {
        Node<int> Aux = List.Head;
        List.Head = List.Tail;
        List.Tail = Aux;

        Node<int> Current = List.Head;
        while (Current != null) {
            Aux = Current.Next;
            Current.Next = Current.Previous;
            Current.Previous = Aux;
            Current = Current.Next;
        }
        return List;
    }

    public static DoublyLinkedList<int> MergeSort(DoublyLinkedList<int> ListA, DoublyLinkedList<int> ListB, SortDirection direction)
    {
        if (direction == SortDirection.Ascending)
        {
            ListA = MergeSortAscending(ListA, ListB);
        }
        else
        {
            ListA = MergeSortDescending(ListA, ListB);
        }

        return ListA;
    }

    public static DoublyLinkedList<int> MergeSortAscending(DoublyLinkedList<int> ListA, DoublyLinkedList<int> ListB)
    {
        DoublyLinkedList<int> ListC = new DoublyLinkedList<int>();
        Node<int> CurrentA = ListA.Head;
        Node<int> CurrentB = ListB.Head;

        while (CurrentA != null && CurrentB != null)
        {
            if (CurrentA.Value < CurrentB.Value)
            {
                ListC.Insert(CurrentA.Value);
                CurrentA = CurrentA.Next;
            }
            else
            {
                ListC.Insert(CurrentB.Value);
                CurrentB = CurrentB.Next;
            }
        }

        while (CurrentA != null)
        {
            ListC.Insert(CurrentA.Value);
            CurrentA = CurrentA.Next;
        }

        while (CurrentB != null)
        {
            ListC.Insert(CurrentB.Value);
            CurrentB = CurrentB.Next;
        }

        return ListC;
    }

    public static DoublyLinkedList<int> MergeSortDescending(DoublyLinkedList<int> ListA, DoublyLinkedList<int> ListB)
    {
        DoublyLinkedList<int> ListC = new DoublyLinkedList<int>();
        Node<int> CurrentA = ListA.Head;
        Node<int> CurrentB = ListB.Head;

        while (CurrentA != null && CurrentB != null)
        {
            if (CurrentA.Value > CurrentB.Value)
            {
                ListC.Insert(CurrentA.Value);
                CurrentA = CurrentA.Next;
            }
            else
            {
                ListC.Insert(CurrentB.Value);
                CurrentB = CurrentB.Next;
            }
        }

        while (CurrentA != null)
        {
            ListC.Insert(CurrentA.Value);
            CurrentA = CurrentA.Next;
        }

        while (CurrentB != null)
        {
            ListC.Insert(CurrentB.Value);
            CurrentB = CurrentB.Next;
        }

        return ListC;
    }

    public static int GetMiddle(DoublyLinkedList<int> List)
    {
        return List.Middle.Value;
    }

}

public class DoublyLinkedList<T>
{
    public Node<T> Head;
    public Node<T> Tail;
    public Node<T> Middle;
    public int Count = 0;
    public void Insert(T Value)
    {
        Node<T> NewNode = new Node<T>();
        NewNode.Value = Value;

        if (Head == null)
        {
            Head = NewNode;
            Tail = NewNode;
            Middle = NewNode;
        }
        else
        {
            Tail.Next = NewNode;
            NewNode.Previous = Tail;
            Tail = NewNode;
            // Set middle without iterating the list
            if (Count % 2 == 0)
            {
                Middle = Middle.Next;
            }

        }
        Count++;
    }

    public T DeleteFirst()
    {
        // Deletes the first element of the doubly linked list and returns it
        if (Head == null)
        {
            return default(T);
        }
        else
        {
            Node<T> Aux = Head;
            Head = Head.Next;
            Head.Previous = null;
            Count--;
            return Aux.Value;
        }
    }

    public T DeleteLast()
    {
        // Deletes the last element of the doubly linked list and returns it
        if (Tail == null)
        {
            return default(T);
        }
        else
        {
            Node<T> Aux = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            Count--;
            return Aux.Value;
        }
    }

    public void Print()
    {
        Node<T> Current = Head;
        while (Current != null)
        {
            Console.WriteLine(Current.Value);
            Current = Current.Next;
        }
    }

}

public class Node<T>
{
    public T Value;
    public Node<T> Next;
    public Node<T> Previous;
}