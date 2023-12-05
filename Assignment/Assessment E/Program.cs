using System;

namespace ASSESSMENT2
{
    class Program
    {
        static void Main(string [] args)
        {
            // int num = 5;
            // int pwr = 3;
            // Console.WriteLine(PowerMethod(num,pwr));
            // int num = 371;
            // ArmstrongNumber(num);
            // int[,] array1 ={{1,2,3},{1,1,1}};
            // int[,] array2 = {{1,1,1},{0,0,0}};
            // foreach(var item in SumTwoRectangularArray(array1 , array2))
            // {
            //     Console.Write($" {item} ");
            // }
            // int[] array ={7,5,8,2,5};
            // TopArray(array);
            // int num = 10;
            // Console.WriteLine(FindMultiplesOf3and5(num));
            // int[][] myJagged = new int [2][]{
            //     new int [3]{1,2,4},
            //     new int[2]{4,6}
            // };
            // JaggedArray(myJagged);
            // int[,] array1 ={{1,2,3},{1,1,1}};
            // PrinttheSubArray(array1);
            // int kthnum = 2;
            // int[] array = {2,4,6,7,5,6,7,4,6};
            // FindTheKthSmallestElement(array, kthnum);
            int [] a = {2,4,6,7,8,9,4,5,7,8,5,3,2,12,1};
            foreach( int item in EvenNumberBeforeOdd(a))
            {
                Console.Write($" {item} ");
            }

            
        }

        //Number1
        static int PowerMethod(int num , int value) 
        {
            int power = 1;
            for(int i =0; i < value; i++)
            {
                power *= num;
            }
            return power;
        }
    
        //Number2
        static void ArmstrongNumber(int num)
        {
            string word = num.ToString();
            int length = word.Length;
            int sum =0;
            for(int i =0; i< length; i++)
            {
                sum += PowerMethod(int.Parse(word[i].ToString()),length);
            }
            Console.WriteLine(sum);
        }

        //Number3
        static int[,] SumTwoRectangularArray(int[,] a, int[,] b)
        {
            int [,] c = new int[a.GetLength(0),a.GetLength(1)];
            {
                for(int i =0, j=0; i< a.GetLength(0); i++,j++)
                {
                    for(int k =0, l=0; k< a.GetLength(1); k++,l++)
                    {
                        c[i,k] = a[i,k] + b[j,l];
                    }
                }
            }
            return c;
        }
        //Number 4
        static void TopArray(int [] ar)
        {
            int smallest = int.MaxValue;
            int sum =0, count =0;
            for(int i =0; i < ar.Length; i++)
            {
                if(smallest > ar[i])
                {
                    smallest = ar[i];
                }
                sum+= ar[i];
                count ++;
            }
            int average = sum/count;
            if(average > smallest)
            {
                Console.WriteLine("It is a Top Array");
            }
            else
            {
                Console.WriteLine("It is not a Top Array");
            }
        }
    
        
        
        //Number 6
        static int FindMultiplesOf3and5(int num)
        {
            int sum = 0;
            if(num < 0)
            {
              return 0;  
            }
                for(int i =1; i < num;i ++)
                {
                    if(i % 3 ==0 || i % 5 == 0)
                    {
                       sum = sum +i;
                    }
                }
            
            return sum;  
        }
    
        //Number 7
         static void JaggedArray(int[][] jayarray)
         {
            int largest = int.MinValue;
            int sum = 0,average =0, rowNum = -1;
            for(int row =0; row < jayarray.Length;row++)
            {
                for(int col =0; col < jayarray[row].Length; col++)
                {
                    sum += jayarray[row][col];
                }
                average = sum / jayarray[row].Length-1;
                if(largest < average)
                {
                    largest = average;
                    rowNum=row+1;
                }
            }
            Console.WriteLine($" The row with the largest average is {rowNum}");
        }

        //Number 8
        static void PrinttheSubArray(int[,] arr)
        {
            int largest = int.MinValue;
            int add = 0 , rowNum =-1;
            
            for(int i =0; i < arr.GetLength(0) ;i++)
            {
                add =0;
                for(int j = 0 ; j < arr.GetLength(1); j++)
                {
                    add += arr[i,j];
                    
                }
                if(largest < add)
                {
                    largest = add;
                    rowNum = i;
                }
                
            }
            for(int k =0 ; k< arr.GetLength(1); k++)
            {
                Console.Write($" {arr[rowNum,k]} ");
            }
            Console.WriteLine($" The sum of the largest sub array is  {largest}");
        }

    
        //Number 9
        static void FindTheKthSmallestElement(int[] a , int kth)
        {
            for(int i =0 ; i< a.Length-1; i++)
            {
                for(int j =i+1 ;j< a.Length-1; j++)
                {
                if(a[i] > a[j])
                {
                    a[i]= a[i] +a[j];
                    a[j]= a[i] - a[j];
                    a[i] = a[i]- a[j];
                }
                }
            }
            Console.WriteLine($"The kth smallest element is {a[kth]}");
        }
    
        //Number 10
        static int[] EvenNumberBeforeOdd(int[] arr)
        {
            for(int i =0 ; i< arr.Length; i++)
            {
                for(int j =i+1 ;j< arr.Length; j++)
                {
                if(arr[i] % 2 != 0 && arr[j] %2 ==0)
                {
                    arr[i]= arr[i] +arr[j];
                    arr[j]= arr[i] - arr[j];
                    arr[i] = arr[i]- arr[j];
                }
                }
            }
            return arr;
        }
    }
}