///butun sonlar
byte son0 = 255;                //1 bayt => 8 bit 2**8
short son1 = 32767;             //         16 bit 2**16
int son2 = 2147483647;          //           32 bit 2**32
long son3 = 9223372036854775807;//          64 bit 2**64

Int16 son4 = 32767;              //          16 bit 2**16
Int32 son5 = 2147483647;         //          32 bit 2**32
Int64 son6 = 9223372036854775807;//          64 bit 2**64
//Int128 -> .Net 8 da

Console.WriteLine(int.MaxValue);


//o'nlik sonlar
float son7 = 3.242F;            //4 bayt => 32 bit
double son8 = 5.623D;           //8 bayt => 64 

//decimal
decimal son9 = 244.873M;        //16 bayt => 128 bit


//o'qishliroq son
decimal son10 = 1_245_243;
Console.WriteLine(son10);


///Dynamic
dynamic name1 = "Sardor";
dynamic name2 = "Sarvar";
DynamicAdd(name1, name2);

dynamic number1 = 1;
dynamic number2 = 2;
DynamicAdd(number1, number2);

void DynamicAdd(object variable1, object variable2)
{
    var result = (dynamic)variable1 + (dynamic)variable2;
    Console.WriteLine(result);
}



//input
var input = Console.ReadLine();


//tryparse
string numberString1 = "672";
int.TryParse(numberString1, out int result1);
Console.WriteLine(result1);

string numberString2 = "672son";
int.TryParse(numberString2, out int result2);
Console.WriteLine(result2);//default qiymat chiqib qoldi

