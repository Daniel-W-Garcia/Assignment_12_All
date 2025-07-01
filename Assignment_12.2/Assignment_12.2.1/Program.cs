/*
1. Listen (and ask questions),
2. Generate Examples (that cover all pertinent cases and corner cases),
3. Brute Force (pseudo),
4. Optimize,
5. Walk Through,
6. Test,
7. Implement (code),
8. Test Again

Given the head of a linked list and an integer val, remove all the nodes of the linked list that has Node.val == val, and return the new head.

I'm not even gonna chage this first part since it's the same as 12.1.2
gotta do it from scratch *sigh* :) jk Deepali
create a custom ListNode class

create a class to populate a linked list
create a method to check for palindrome.

then you just check if node.next == inputValue you're looking for. then just link the prev value to the next value to slice out the matching node


*/

using System.ComponentModel.DataAnnotations;

static ListNode RemoveMatchingNodes(ListNode head, int val)
{
    if (head == null) return null;
    ListNode temp = new ListNode(0);
    temp.Next = head; // input node assigned to next value after the temp node
    ListNode prev = temp; // temp is now shuffled back to the beginning of the list
    ListNode curr = head; // curr is also assigned the input 'head' value

    while (curr != null)
    {
        if (curr.Value == val) // looking for a match
        {
            prev.Next = curr
                .Next; //if there's a match assign the pointer to point to the next node and skip over the matching node
        }
        else
        {
            prev = curr; // keep both pointers moving to the right until there's a match
        }

        curr = curr.Next;
    }
    return temp.Next; // return the head of the new linked list
}

Console.WriteLine();
Console.WriteLine("Test Case 1: Single Node List:");
LinkedList singleNodeLinkedList = new LinkedList();
singleNodeLinkedList.AddLast(1);
Console.Write("List before removal of values: ");
singleNodeLinkedList.Display(singleNodeLinkedList.head);
RemoveMatchingNodes(singleNodeLinkedList.head, 1);
var linkedList = RemoveMatchingNodes(singleNodeLinkedList.head, 1);
Console.Write(linkedList == null ? "List is now empty" : string.Join(", ", linkedList));
Console.WriteLine();

Console.WriteLine();
Console.WriteLine("Test 2:");
LinkedList inputList = new LinkedList();
inputList.AddLast(5);
inputList.AddLast(4);
inputList.AddLast(3);
inputList.AddFirst(6);
inputList.AddLast(4);
inputList.AddLast(5);
inputList.AddLast(6);

Console.Write("List before removal of values : ");
inputList.Display(inputList.head);

Console.Write("List after removal: ");
var linkedList2 = RemoveMatchingNodes(inputList.head, 6);
LinkedList.DisplayList(linkedList2);
Console.WriteLine();


public class ListNode
{
    public int Value { get; set; } //used props this time. think it looks cooler
    public ListNode Next { get; set; }

    public ListNode(int value = 0, ListNode next = null)
    {
        Value = value;
        Next = next;
    }
}

public class LinkedList 
{
    public ListNode head;
    
    public LinkedList() 
    {
        head = null;
    }
    
    // Add node at the end
    public void AddLast(int value) 
    {
        ListNode newNode = new ListNode(value);
        
        if (head == null) 
        {
            head = newNode;
            return;
        }
        
        ListNode current = head;
        while (current.Next != null) 
        {
            current = current.Next;
        }
        current.Next = newNode;
    }
    
    // Add node at the beginning
    public void AddFirst(int value) 
    {
        ListNode newNode = new ListNode(value, head);
        head = newNode;
    }
    
    // Display the linked list
    public void Display(ListNode head) 
    {
        if (head == null) 
        {
            Console.WriteLine("List is now empty");
            return;
        }
    
        List<int> values = new List<int>();
        ListNode current = head;
        while (current != null) 
        {
            values.Add(current.Value);  
            current = current.Next;
        }
        Console.WriteLine($"[{string.Join(",", values)}]");
    }
    
    // Display the linked list with static method. violating DRY principle but annoyed I couldn't figure out a different way
    public static void DisplayList(ListNode head) 
    {
        if (head == null) 
        {
            Console.WriteLine("List is now empty");
            return;
        }
    
        List<int> values = new List<int>();
        ListNode current = head;
        while (current != null) 
        {
            values.Add(current.Value);  
            current = current.Next;
        }
        Console.WriteLine($"[{string.Join(",", values)}]");
    }

    
    // Get the size of the linked list
    public int Size() 
    {
        int count = 0;
        ListNode current = head;
        while (current != null) 
        {
            count++;
            current = current.Next;
        }
        return count;
    }
    
    // Clear the linked list
    public void Clear() 
    {
        head = null;
    }
    
    // Check if the linked list is empty
    public bool IsEmpty() 
    {
        return head == null;
    }
}