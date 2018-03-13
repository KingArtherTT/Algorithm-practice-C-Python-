using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductofArrayExceptSelf
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] result= ProductExceptSelf(new int[] { 1, 2, 3, 4 });
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            //时间复杂度在O(n),故不使用嵌套循环
     
            if (nums.Length <= 1)
            {
                return nums;
            }
            int[] result = new int[nums.Length];
            long allProduct = 1;//记录原数组所有项的乘积
            int count0 = 0;//记录原数组中0出现的次数
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] == 0)
                {
                    count0++;
                    continue;
                }
                allProduct *= nums[j];
            }
            if (count0 >= 2)
            {
                //原数组中0的个数大于等于2 则输出数组全为0
                return result;
            }
            for (int i = 0; i < result.Length; i++)
            {
                if (nums[i] == 0)
                {
                    //原数组中0的个数等于1，则输出数组中除当前元素外，其余元素均为0
                    result = new int[nums.Length];
                    result[i] = (int)allProduct;
                    return result;
                }
                else
                {
                    //原数组中没有0元素，正常输出
                    result[i] = (int)(allProduct / nums[i]);
                }
            }
            return result;
        }
    }
}
