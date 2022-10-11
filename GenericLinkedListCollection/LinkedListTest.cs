namespace GenericLinkedListCollection
{
    internal class LinkedListTest
    {
        private static readonly string[] colors = { "black", "yellow", "green", "blue", "violet", "silver" };
        private static readonly string[] colors2 = { "gold", "white", "brown", "blue", "gray" };

        // Set up and manipulate LinkedList objects 
        static void Main(string[] args)
        {
            var list1 = new LinkedList<string>();

            // Add elements to the first linked list
            foreach(var color in colors)
            {
                list1.AddLast(color);
            }

            // Add elements to the second linked list via constructor
            var list2 = new LinkedList<string>(colors2);

            Concatenate(list1, list2);  // Concatenate list2 onto list1
            PrintList(list1);  // Display list1 elements

            Console.WriteLine("\nConverting strings in list1 to uppercase\n");
            ToUppercaseStrings(list1); // Convert to uppercase string
            PrintList(list2);

            Console.WriteLine("\nDeleting strings between BLACK and BROWN\n;");
            RemoveItemsBetween(list1, "BLACK", "BROWN");

            PrintList(list1);
            PrintReversedList(list1);
        }

        private static void PrintList<T>(LinkedList<T> list)
        {
            Console.WriteLine("Linked list: ");

            foreach(var value in list)
            {
                Console.Write($"{value} ");
            }

            Console.WriteLine();
        }

        // Concatenate
        private static void Concatenate<T>(LinkedList<T> list1, LinkedList<T> list2)
        {
            foreach (var value in list2)
            {
                list1.AddLast(value);
            }
        }

        // Locate string objects and convert to uppercase
        private static void ToUppercaseStrings(LinkedList<string> list)
        {
            // Iterate over the list by using nodes
            LinkedListNode<string> currentNode = list.First;

            while(currentNode != null)
            {
                string color = currentNode.Value;
                currentNode.Value = color.ToUpper();
                currentNode = currentNode.Next;
            }
        }

        // Delete list items 
        private static void RemoveItemsBetween<T>(LinkedList<T> list, T startItem, T endItem)
        {
            // Get the nodes corrresponding to the start and end items
            LinkedListNode<T> currentNode = list.Find(startItem);
            LinkedListNode<T> endNode = list.Find(endItem);

            // Remove items after the start item
            // until we find the last item or the end of the linked list
            while ((currentNode.Next != null) && (currentNode.Next != endNode))
            {
                list.Remove(currentNode.Next);
            }
        }

        // Display
        private static void PrintReversedList<T>(LinkedList<T> list)
        {
            Console.WriteLine("Reversed list:");

            // Iterate over the list by using the nodes
            LinkedListNode<T> currentNode = list.Last;

            while (currentNode != null)
            {
                Console.Write($"{currentNode.Value} ");
                currentNode = currentNode.Previous;
            }

            Console.WriteLine();
        }
    }
}