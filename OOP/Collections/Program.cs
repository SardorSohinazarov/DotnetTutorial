/*using Collections;

MeningCollectionim collectionim = new MeningCollectionim();

collectionim.GetAllItems();

collectionim.Add(1);
collectionim.Add(5);

collectionim.GetAllItems();

collectionim.RemoveFromStart();

Console.WriteLine("O'chirildi");

collectionim.GetAllItems();

collectionim.Add(10);

collectionim.GetAllItems();

collectionim.RemoveFromEnd();

collectionim.GetAllItems();

*/

/*using Collections;

MyList myList = new MyList();

Console.WriteLine("0-langth: " + myList.GetLength());

myList.Add(1);

Console.WriteLine("1-langth: " + myList.GetLength());

myList.GetMyArrayList();

myList.RemoveFromEnd();

myList.GetMyArrayList();

myList.Add(1);
myList.Add(2);
myList.Add(3);
myList.Add(4);
myList.Add(5);

myList.GetMyArrayList();
*/



IList<int> list = new List<int>()
{
    1,2,3, 4,5,6,7,8,9,10
};

Console.WriteLine(list.Average());