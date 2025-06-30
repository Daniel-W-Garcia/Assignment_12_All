/*
1. Listen (and ask questions),
2. Generate Examples (that cover all pertinent cases and corner cases),
3. Brute Force (pseudo),
4. Optimize,
5. Walk Through,
6. Test,
7. Implement (code),
8. Test Again

gotta do it from scratch *sigh* :) jk Deepali
create a custom ListNode class

create a class to populate a linked list
create a method to check for palindrome.
*/

DeterminePalindrome palindromeChecker = new DeterminePalindrome();

Console.WriteLine();
Console.WriteLine("Test Case 1: Single Node List:");
LinkedList singleNodeLinkedList = new LinkedList();
singleNodeLinkedList.AddLast(1);
Console.Write("List: ");
singleNodeLinkedList.Display();
Console.WriteLine($"Is Palindrome: {palindromeChecker.IsPalindrome(singleNodeLinkedList.head)}");
Console.WriteLine($"Size: {singleNodeLinkedList.Size()}\n");

Console.WriteLine("Test 2: Shouldn't be Palindrome:");
LinkedList inputList = new LinkedList();
inputList.AddLast(5);
inputList.AddLast(4);
inputList.AddLast(3);
inputList.AddFirst(6);
Console.Write("List: ");
inputList.Display();
Console.WriteLine($"Is Palindrome: {palindromeChecker.IsPalindrome(inputList.head)}\n");

// and nodes to make it a palindrome
inputList.AddLast(4);
inputList.AddLast(5);
inputList.AddLast(6);
Console.Write("Modified List: ");
inputList.Display();
Console.WriteLine($"Is Palindrome: {palindromeChecker.IsPalindrome(inputList.head)}");
Console.WriteLine($"Size: {inputList.Size()}\n");



// class to create a linked list of ints
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
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
        while (current.next != null) 
        {
            current = current.next;
        }
        current.next = newNode;
    }
    
    // Add node at the beginning
    public void AddFirst(int value) 
    {
        ListNode newNode = new ListNode(value, head);
        head = newNode;
    }
    
    // Display the linked list
    public void Display() 
    {
        if (head == null) 
        {
            Console.WriteLine("Empty list");
            return;
        }
        
        List<int> values = new List<int>();
        ListNode current = head;
        while (current != null) 
        {
            values.Add(current.val);
            current = current.next;
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
            current = current.next;
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

// class to determine if a linked list is a palindrome
public class DeterminePalindrome
{
    public bool IsPalindrome(ListNode head)
    {
        if (head == null) return true;

        List<int> values = new List<int>();
        ListNode current = head;

        while (current != null)
        {
            values.Add(current.val);
            current = current.next;
        }

        int left = 0, right = values.Count - 1;
        while (left < right)
        {
            if (values[left] != values[right])
                return false;
            left++;
            right--;
        }
        return true;
    }
}






