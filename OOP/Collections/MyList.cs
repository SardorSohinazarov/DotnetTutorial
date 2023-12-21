namespace Collections;

public class MeningCollectionim
{
    private int[] arr;
    private int leftPointer;
    private int rightPointer;
    public MeningCollectionim()
    {
        arr = new int[10];
        leftPointer = 0;
        rightPointer = 0;
    }

    public void Add(int value)
    {
        if(rightPointer == arr.Length)
        {
            Array.Resize(ref arr, arr.Length * 2);
        }

        arr[rightPointer] = value;
        rightPointer++;
    }

    public void RemoveFromStart()
    {
        leftPointer ++;
    }

    public void GetAllItems()
    {
        for(int i = leftPointer; i < rightPointer; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }

    public void RemoveFromEnd()
    {
        if(rightPointer > leftPointer)
            rightPointer--;
    }
}

































/*using System.Collections;

namespace Collections
{
    public class MyList
    {
        private int[] arr;
        private int pointer;

        public MyList()
        {
            pointer = 0;
            arr = new int[10];
        }

        public int GetLength()
        {
            return pointer;
        }

        public void Add(int newValue)
        {
            if(arr.Length > pointer + 1)
            {
                arr[pointer] = newValue;
            }
            else
            {
                Array.Resize(ref arr, arr.Length * 2);
                arr[pointer] = newValue;
            }
            pointer ++;
        }

        public void GetMyArrayList()
        {
            for (int i = 0; i < pointer; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public void RemoveFromEnd()
        {
            if(pointer > 0)
            {
                pointer --;
            }
        }
    }
}
*/