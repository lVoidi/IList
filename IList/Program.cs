
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
        listA.BuildFromArray(new int[] {  3, 4, 5, 1, 2, });

        DoublyLinkedList<int> listB = Invert(listA);

        listA.Print();
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
        return null;
    }

    public static void GetMiddle()
    {

    }

    private void InsertInOrder()
    {

    }

    private void DeleteFirst()
    {

    }
}

public class DoublyLinkedList<T>
{
    public Node<T> Head;
    public Node<T> Tail;
    public int Count;

    public DoublyLinkedList()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public void BuildFromArray(T[] array)
    {
        foreach (T value in array)
        {
            AddLast(value);
        }
    }

    public void AddFirst(T value)
    {
        Node<T> node = new Node<T>
        {
            Value = value,
            Next = Head,
            Previous = null
        };

        if (Head != null)
        {
            Head.Previous = node;
        }
        else
        {
            Tail = node;
        }

        Head = node;
        Count++;
    }

    public void AddLast(T value)
    {
        Node<T> node = new Node<T>
        {
            Value = value,
            Next = null,
            Previous = Tail
        };

        if (Tail != null)
        {
            Tail.Next = node;
        }
        else
        {
            Head = node;
        }

        Tail = node;
        Count++;
    }

    public void AddAfter(Node<T> node, T value)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }

        Node<T> newNode = new Node<T>
        {
            Value = value,
            Next = node.Next,
            Previous = node
        };

        node.Next = newNode;

        if (newNode.Next != null)
        {
            newNode.Next.Previous = newNode;
        }
        else
        {
            Tail = newNode;
        }

        Count++;
    }

    public void AddBefore(Node<T> node, T value)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }

        Node<T> newNode = new Node<T>
        {
            Value = value,
            Next = node,
            Previous = node.Previous
        };

        node.Previous = newNode;

        if (newNode.Previous != null)
        {
            newNode.Previous.Next = newNode;
        }
        else
        {
            Head = newNode;
        }

        Count++;
    }

    public void RemoveFirst()
    {
        if (Head == null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        Head = Head.Next;
        Count--;

        if (Head == null)
        {
            Tail = null;
        }
        else
        {
            Head.Previous = null;
        }
    }

    public void RemoveLast()
    {
        if (Tail == null)
        {
            throw new InvalidOperationException("The list is empty");
        }

        Tail = Tail.Previous;
        Count--;

        if (Tail == null)
        {
            Head = null;
        }
        else
        {
            Tail.Next = null;
        }
    }

    public void Remove(Node<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }

        if (node.Previous != null)
        {
            node.Previous.Next = node.Next;
        }
        else
        {
            Head = node.Next;
        }

        if (node.Next != null)
        {
            node.Next.Previous = node.Previous;
        }
        else
        {
            Tail = node.Previous;
        }

        Count--;
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public Node<T> Find(T value)
    {
        Node<T> current = Head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    public bool Contains(T value)
    {
        return Find(value) != null;
    }

    public void Print()
    {
        Node<T> current = Head;

        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }

    public void PrintReverse()
    {
        Node<T> current = Tail;

        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Previous;
        }
    }

    public T[] ReturnLinkedListAsArray()
    {
        T[] array = new T[Count];
        Node<T> current = Head;
        int index = 0;

        while (current != null)
        {
            array[index++] = current.Value;
            current = current.Next;
        }

        return array;
    }
}

public class Node<T>
{
    public T Value;
    public Node<T> Next;
    public Node<T> Previous;
}